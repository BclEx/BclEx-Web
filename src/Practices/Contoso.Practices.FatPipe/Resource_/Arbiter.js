// ["ErrorUtils", "copyProperties", "createArrayFrom", "hasArrayNature"], 

function (a, b, c, d, e, f) {
    var g = b('ErrorUtils'), h = b('copyProperties'), i = b('createArrayFrom'), j = b('hasArrayNature');
    if (!window.async_callback) window.async_callback = function (m, n) { return m; }; 


    function k() { h(this, { _listeners: [], _events: {}, _callbacks: {}, _last_id: 1, _listen: {}, _index: {} }); h(this, k); }
    h(k, { 
        SUBSCRIBE_NEW: 'new', 
        SUBSCRIBE_ALL: 'all', 
        BEHAVIOR_EVENT: 'event', 
        BEHAVIOR_PERSISTENT: 'persistent', 
        BEHAVIOR_STATE: 'state', 
        LIVEMESSAGE: 'livemessage', 
        BOOTLOAD: 'bootload', 
        FUNCTION_EXTENSION: 'function_ext', 
        //
        subscribe: function (m, n, o) { 
            m = i(m); 
            var p = m.some(function (x) { return !x || typeof (x) != 'string'; }); 
            if (p) return null; 
            o = o || k.SUBSCRIBE_ALL; 
            var q = k._getInstance(this); 
            q._listeners.push({ callback: n, types: m }); 
            var r = q._listeners.length - 1; 
            for (var s = 0; s < m.length; s++) { 
                var t = m[s]; 
                if (!q._index[t]) q._index[t] = []; 
                q._index[t].push(r); 
                if (o == k.SUBSCRIBE_ALL) 
                    if (t in q._events) 
                        for (var u = 0; u < q._events[t].length; u++) { 
                            var v = q._events[t][u], w = g.applyWithGuard(n, null, [t, v]); 
                            if (w === false) { q._events[t].splice(u, 1); u--; } 
                        } 
            }
            return new l(q, r); }, 
        //
        unsubscribe: function (m) { m.unsubscribe(); },
        //
        inform: function (m, n, o) { 
            var p = j(m); 
            m = i(m); 
            var q = k._getInstance(this), r = {};
            o = o || k.BEHAVIOR_EVENT; 
            for (var s = 0; s < m.length; s++) { 
                var t = m[s], u = null; 
                if (o == k.BEHAVIOR_PERSISTENT) { u = q._events.length; if (!(t in q._events)) q._events[t] = []; q._events[t].push(n); q._events[t]._stateful = false; } 
                else if (o == k.BEHAVIOR_STATE) { u = 0; q._events[t] = [n]; q._events[t]._stateful = true; } 
                else if (t in q._events) q._events[t]._stateful = false; 
                a.ArbiterMonitor && a.ArbiterMonitor.record('event', t, n, q); 
                var v; 
                if (q._index[t]) { 
                    var w = i(q._index[t]); 
                    for (var x = 0; x < w.length; x++) { 
                        var y = q._listeners[w[x]]; 
                        if (y) { 
                            v = g.applyWithGuard(y.callback, null, [t, n]); 
                            if (v === false) { if (u !== null) q._events[t].splice(u, 1); break; } 
                        } 
                    } 
                } 
                q._updateCallbacks(t, n); 
                a.ArbiterMonitor && a.ArbiterMonitor.record('done', t, n, q); 
                r[t] = v; 
            }
            return p ? r : r[m[0]]; }, 
        //
        query: function (m) { 
            var n = k._getInstance(this); 
            if (!(m in n._events)) return null; 
            if (n._events[m].length) return n._events[m][0]; 
            return null; }, 
        //    
        _instance: null, 
        _getInstance: function (m) { if (m instanceof k) return m; if (!k._instance) k._instance = new k(); return k._instance; }, 
        //
        registerCallback: function (m, n) { 
            var o, p = 0, q = k._getInstance(this), r = false; 
            if (typeof m == 'function') { o = q._last_id; q._last_id++; r = true; } 
            else { if (!q._callbacks[m]) return null; o = m; } 
            if (j(n)) { var s = {}; for (var t = 0; t < n.length; t++) s[n[t]] = 1; n = s; } 
            for (var u in n) { 
                try { if (q.query(u)) continue; } 
                catch (v) { } 
                p += n[u]; 
                if (q._listen[u] === undefined) q._listen[u] = {}; 
                q._listen[u][o] = (q._listen[u][o] || 0) + n[u]; 
            } 
            if (p === 0 && r) { g.applyWithGuard(m); return null; } 
            if (!r) { q._callbacks[o].depnum += p; } 
            else q._callbacks[o] = { callback: window.async_callback(m, 'arbiter'), depnum: p }; 
            return o; }, 
        //
        _updateCallbacks: function (m, n) { 
            if (n === null || !this._listen[m]) return; 
            for (var o in this._listen[m]) { 
                this._listen[m][o]--; 
                if (this._listen[m][o] <= 0) delete this._listen[m][o]; 
                this._callbacks[o].depnum--; 
                if (this._callbacks[o].depnum <= 0) { var p = this._callbacks[o].callback; delete this._callbacks[o]; g.applyWithGuard(p); } 
            } 
        } 
    }); 

    function l(m, n) { this._instance = m; this._id = n; } 
    h(l.prototype, { 
        unsubscribe: function () { 
            var m = this._instance._listeners, n = m[this._id]; 
            if (!n) return; 
            for (var o = 0; o < n.types.length; o++) { 
                var p = n.types[o], q = this._instance._index[p]; 
                if (q) 
                    for (var r = 0; r < q.length; r++) 
                if (q[r] == this._id) { q.splice(r, 1); if (q.length === 0) delete q[p]; break; } 
            } 
            delete m[this._id]; 
        } 
    }); 
    
    e.exports = k; 
});