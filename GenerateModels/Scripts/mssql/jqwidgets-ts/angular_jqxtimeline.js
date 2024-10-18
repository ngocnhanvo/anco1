"use strict";
/*
jQWidgets v20.0.0 (2024-Sep)
Copyright (c) 2011-2024 jQWidgets.
License: https://jqwidgets.com/license/
*/
/* eslint-disable */
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
/// <reference path="jqwidgets.d.ts" />
require("../jqwidgets/jqxcore.js");
require("../jqwidgets/jqxtimeline.js");
var core_1 = require("@angular/core");
var jqxTimelineComponent = /** @class */ (function () {
    function jqxTimelineComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['autoWidth', 'collapsible', 'disabled', 'horizontal', 'position', 'source', 'theme'];
        this.elementRef = containerElement;
    }
    jqxTimelineComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxTimelineComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxTimeline(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxTimeline(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxTimeline(this.properties[i])) {
                        this.host.jqxTimeline(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxTimelineComponent.prototype.arraysEqual = function (attrValue, hostValue) {
        if ((attrValue && !hostValue) || (!attrValue && hostValue)) {
            return false;
        }
        if (attrValue.length != hostValue.length) {
            return false;
        }
        for (var i = 0; i < attrValue.length; i++) {
            if (attrValue[i] !== hostValue[i]) {
                return false;
            }
        }
        return true;
    };
    jqxTimelineComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxTimelineComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxTimelineComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxTimelineComponent.prototype.createComponent = function (options) {
        if (this.host) {
            return;
        }
        if (options) {
            JQXLite.extend(options, this.manageAttributes());
        }
        else {
            options = this.manageAttributes();
        }
        this.host = JQXLite(this.elementRef.nativeElement.firstChild);
        this.moveClasses(this.elementRef.nativeElement, this.host[0]);
        this.moveStyles(this.elementRef.nativeElement, this.host[0]);
        this.__wireEvents__();
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxTimeline', options);
    };
    jqxTimelineComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxTimelineComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxTimelineComponent.prototype.setOptions = function (options) {
        this.host.jqxTimeline('setOptions', options);
    };
    // jqxTimelineComponent properties
    jqxTimelineComponent.prototype.autoWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimeline('autoWidth', arg);
        }
        else {
            return this.host.jqxTimeline('autoWidth');
        }
    };
    jqxTimelineComponent.prototype.collapsible = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimeline('collapsible', arg);
        }
        else {
            return this.host.jqxTimeline('collapsible');
        }
    };
    jqxTimelineComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimeline('disabled', arg);
        }
        else {
            return this.host.jqxTimeline('disabled');
        }
    };
    jqxTimelineComponent.prototype.horizontal = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimeline('horizontal', arg);
        }
        else {
            return this.host.jqxTimeline('horizontal');
        }
    };
    jqxTimelineComponent.prototype.position = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimeline('position', arg);
        }
        else {
            return this.host.jqxTimeline('position');
        }
    };
    jqxTimelineComponent.prototype.source = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimeline('source', arg);
        }
        else {
            return this.host.jqxTimeline('source');
        }
    };
    jqxTimelineComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxTimeline('theme', arg);
        }
        else {
            return this.host.jqxTimeline('theme');
        }
    };
    // jqxTimelineComponent functions
    jqxTimelineComponent.prototype.render = function () {
        return this.host.jqxTimeline('render');
    };
    // jqxTimelineComponent events
    jqxTimelineComponent.prototype.__wireEvents__ = function () {
    };
    __decorate([
        core_1.Input('autoWidth')
    ], jqxTimelineComponent.prototype, "attrAutoWidth", void 0);
    __decorate([
        core_1.Input('collapsible')
    ], jqxTimelineComponent.prototype, "attrCollapsible", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxTimelineComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('horizontal')
    ], jqxTimelineComponent.prototype, "attrHorizontal", void 0);
    __decorate([
        core_1.Input('position')
    ], jqxTimelineComponent.prototype, "attrPosition", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxTimelineComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxTimelineComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxTimelineComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxTimelineComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxTimelineComponent.prototype, "autoCreate", void 0);
    jqxTimelineComponent = __decorate([
        core_1.Component({
            selector: 'jqxTimeline',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxTimelineComponent);
    return jqxTimelineComponent;
}()); //jqxTimelineComponent
exports.jqxTimelineComponent = jqxTimelineComponent;
