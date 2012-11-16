// optional: [append][has_inline_js]


//["Arbiter","Bootloader","Env","JSCC","OnloadEvent","Run","ServerJS","$","copyProperties","ge","hasArrayNature","invokeCallbacks"],


function (a, b, c, d, e, f) {
    var g = b('Arbiter'), h = b('Bootloader'), i = b('Env'), j = b('JSCC'), k = b('OnloadEvent'), l = b('Run'), m = b('ServerJS'), n = b('$'), o = b('copyProperties'), p = b('ge'), q = b('hasArrayNature'), r = b('invokeCallbacks'), s = document.documentMode || +(/MSIE.(\d+)/.exec(navigator.userAgent) || [])[1], t = g.BEHAVIOR_STATE, u = g.BEHAVIOR_PERSISTENT;
    function v(aa) {
        // object initalizer
        return (!aa || q(aa) && aa.length === 0) ? {} : aa;
    }
    function w(aa) {
        // find content contaner and return
        if (!aa || typeof aa === 'string') return aa; if (aa.container_id) { var ba = n(aa.container_id); aa = x(ba) || ''; ba.parentNode.removeChild(ba); return aa; } return null;
    }
    function x(aa) {
        // find comment node and unescape javscript string
        if (!aa.firstChild) { h.loadModules(['ErrorSignal'], function (ca) { ca.sendErrorSignal('bigpipe', 'Pagelet markup container is empty.'); }); return null; }
        if (aa.firstChild.nodeType !== 8) return null;
        var ba = aa.firstChild.nodeValue;
        ba = ba.substring(1, ba.length - 1);
        return ba.replace(/\\([\s\S]|$)/g, '$1');
    }
    function y(aa, ba) {
        // transfer aa to ba
        var ca = document.createElement('div'), da = s < 7;
        if (da) aa.appendChild(ca);
        ca.innerHTML = ba;
        var ea = document.createDocumentFragment();
        while (ca.firstChild) ea.appendChild(ca.firstChild);
        aa.appendChild(ea);
        if (da) aa.removeChild(ca);
    }
    function z(aa) {
        o(this, { arbiter: g, rootNodeID: 'content', lid: 0, isAjax: false, domContentCallback: l.__domcontentCallback, onloadCallback: l.__onloadCallback, domContentEvt: k.ONLOAD_DOMCONTENT_CALLBACK, onloadEvt: k.ONLOAD_CALLBACK, forceFinish: false, jsEarlier: false, _phaseDoneCallbacks: [], _currentPhase: 0, _lastPhase: -1 });
        o(this, aa);
        z._current_instance = this;
        this._serverJS = new m();
        g.inform('BigPipe/init', { lid: this.lid, arbiter: this.arbiter }, u);
        this.arbiter.registerCallback(this._serverJS.cleanup.bind(this._serverJS), ['pagelet_displayed_all']);
        this.arbiter.registerCallback(this.domContentCallback, ['pagelet_displayed_all']);
        this._informEventExternal('phase_begin', { phase: 0 });
        this.arbiter.inform('phase_begin_0', true, t);
        this.onloadCallback = this.arbiter.registerCallback(this.onloadCallback, ['pagelet_displayed_all']);
    }
    o(z.prototype, {

        // run this.displayCallback(_displayPagelet()) or _displayPagelet()
        _displayPageletHandler: function (aa) { if (this.displayCallback) { this.displayCallback(this._displayPagelet.bind(this, aa)); } else this._displayPagelet(aa); },

        //
        _displayPagelet: function (aa) {
            this._informPageletEvent('display_start', aa.id);
            aa.content = v(aa.content);
            var ba = true, ca = function () { this._informPageletEvent('display', aa.id); this.arbiter.inform(aa.id + '_displayed', true, t); } .bind(this);
            // walk through all content objects
            for (var da in aa.content) {
                var ea = aa.content[da];
                // if append defined then overide all properies to append
                if (aa.append) da = this._getAppendTargetID(aa);
                // look up code node
                var fa = p(da);
                if (fa) {
                    // look up code node.value
                    ea = w(ea);
                    if (ea)
                        if (!aa.append && aa.has_inline_js) {
                            if (a.DOM && a.HTML) {
                                DOM.setContent(fa, HTML(ea));
                            } else {
                                ba = false;
                                h.loadModules(['DOM', 'HTML'], function (ha, ia) { ha.setContent(fa, ia(ea)); ca(); });
                            }
                        } else if (aa.append || s < 8) {
                            if (!aa.append) while (fa.firstChild) fa.removeChild(fa.firstChild);
                            y(fa, ea);
                        } else fa.innerHTML = ea;
                    // if data-referrer defines then attach content
                    var ga = fa.getAttribute('data-referrer');
                    if (!ga) fa.setAttribute('data-referrer', da);
                }
            }
            if (ba) ca();
            if (aa.cache_hit && i.pc_debug == 1) n(aa.id).style.border = "1px red solid";
        },

        //
        _getAppendTargetID: function (aa) { if (!aa.append) return null; return (aa.append === 'bigpipe_root') ? this.rootNodeID : aa.append; },

        //
        _downloadJsForPagelet: function (aa) {
            this._informPageletEvent('jsstart', aa.id);
            h.loadResources(aa.js || [], function () {
                this._informPageletEvent('jsdone', aa.id);
                aa.requires = aa.requires || [];
                if (!this.isAjax || aa.phase >= 1) aa.requires.push('uipage_onload');
                var ba = function () {
                    this._isRelevantPagelet(aa) && r(aa.onload);
                    this._informPageletEvent('onload', aa.id);
                    this.arbiter.inform('pagelet_onload', true, g.BEHAVIOR_EVENT);
                    aa.provides && this.arbiter.inform(aa.provides, true, t);
                } .bind(this), ca = function () {
                    this._isRelevantPagelet(aa) && r(aa.onafterload);
                } .bind(this);
                this.arbiter.registerCallback(ba, aa.requires);
                this.arbiter.registerCallback(ca, [this.onloadEvt]);
            } .bind(this), false, aa.id);
        },
        //
        _downloadCssAndDisplayPagelet: function (aa) {
            this._informPageletEvent('css', aa.id);
            h.loadResources(aa.css || [], function () {
                var ba = aa.display_dependency || [], ca = [];
                for (var da = 0; da < ba.length; da++) ca.push(ba[da] + '_displayed');
                this.arbiter.registerCallback(this._displayPageletHandler.bind(this, aa), ca);
            } .bind(this), false, aa.id);
            this._informPageletEvent('css_end', aa.id);
        },
        //
        _downloadAndScheduleDisplayJS: function (aa) {
            var ba = aa.js || [], ca = [];
            for (var da = 0; da < ba.length; da++) if (h.isDisplayJS(ba[da])) ca.push(ba[da]);
            h.loadResources(ca, function () {
                if (aa.ondisplay && aa.ondisplay.length) this.arbiter.registerCallback(function () { r(aa.ondisplay); }, [aa.id + '_displayed']);
            } .bind(this));
        },
        //
        onPageletArrive: function (aa) {
            this._informPageletEvent('arrive', aa.id, aa.phase);
            var ba = aa.phase;
            if (!this._phaseDoneCallbacks[ba]) this._phaseDoneCallbacks[ba] = this.arbiter.registerCallback(this._onPhaseDone.bind(this), ['phase_complete_' + ba]);
            this.arbiter.registerCallback(this._phaseDoneCallbacks[ba], [aa.id + '_displayed']);
            if (aa.cacheable) {
                if (aa.cache_hit) {
                    this._processPagelet(PageletCache.loadFromCache(aa));
                } else {
                    PageletCache.write(aa);
                    this._processPagelet(aa);
                } 
            } else this._processPagelet(aa);
            this._informPageletEvent('arrive_end', aa.id);
        },
        //
        _processPagelet: function (aa) {
            var ba = aa.phase, ca = this._getAppendTargetID(aa) || aa.id;
            z.pageletIDs[ca] = ca;
            if (aa.the_end) this._lastPhase = aa.phase;
            if (aa.tti_phase !== undefined) this._ttiPhase = aa.tti_phase;
            if (aa.is_second_to_last_phase) this._secondToLastPhase = aa.phase;
            if (aa.jscc_map) {
                var da = (eval)(aa.jscc_map);
                j.initForPagelet(ca, da);
            } h.setResourceMap(aa.resource_map);
            h.enableBootload(v(aa.bootloadable));
            var ea = 'phase_begin_' + ba;
            this.arbiter.registerCallback(this._downloadCssAndDisplayPagelet.bind(this, aa), [ea]);
            this.arbiter.registerCallback(this._downloadAndScheduleDisplayJS.bind(this, aa), [ea]);
            var fa = [aa.id + '_displayed'];
            if (!this.jsNonBlock) if (this.jsEarlier) {
                fa.push('start_to_download_js');
            } else fa.push(this.domContentEvt);
            if (aa.jsmods) this.arbiter.registerCallback(this._serverJS.handlePartial.bind(this._serverJS, aa.jsmods), [aa.id + '_displayed']);
            this.arbiter.registerCallback(this.onloadCallback, ['pagelet_onload']);
            this.arbiter.registerCallback(this._downloadJsForPagelet.bind(this, aa), fa);
            aa.is_last && this.arbiter.inform('phase_complete_' + ba, true, t);
        },

        _onPhaseDone: function () {
            if (this._currentPhase === this._ttiPhase) this._informEventExternal('tti_bigpipe', { phase: this._ttiPhase });
            var aa = this._currentPhase + 1, ba = (function (ca) {
                    if (this.jsEarlier && ca) this.arbiter.inform('start_to_download_js', true, t);
                    this._informEventExternal('phase_begin', { phase: aa });
                    this.arbiter.inform('phase_begin_' + aa, true, t);
                }).bind(this, this._currentPhase === this._secondToLastPhase);
            if (this._currentPhase === this._lastPhase && this._isRelevant()) this.arbiter.inform('pagelet_displayed_all', true, t);
            this._currentPhase++;
            if (s) { setTimeout(ba, 20); } else ba();
        },

        _isRelevant: function () { return this == z._current_instance || this.jsNonBlock || this.forceFinish; },

        _isRelevantPagelet: function (aa) { if (!this._isRelevant()) return false; var ba = this._getAppendTargetID(aa) || aa.id; return z.pageletIDs.hasOwnProperty(ba); },

        _informEventExternal: function (aa, ba) { ba = ba || {}; ba.ts = Date.now(); ba.lid = this.lid; this.arbiter.inform(aa, ba, u); },
        _informPageletEvent: function (aa, ba, ca) { var da = { event: aa, id: ba }; if (ca) da.phase = ca; this._informEventExternal('pagelet_event', da); }

    });
    //
    z.pageletIDs = {};
    e.exports = z;
}

