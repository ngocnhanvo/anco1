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
require("../jqwidgets/jqxdata.js");
require("../jqwidgets/jqxbuttons.js");
require("../jqwidgets/jqxscrollbar.js");
require("../jqwidgets/jqxmenu.js");
require("../jqwidgets/jqxwindow.js");
require("../jqwidgets/jqxdragdrop.js");
require("../jqwidgets/jqxcheckbox.js");
require("../jqwidgets/jqxinput.js");
require("../jqwidgets/jqxlistbox.js");
require("../jqwidgets/jqxdropdownlist.js");
require("../jqwidgets/jqxpivot.js");
require("../jqwidgets/jqxpivotgrid.js");
require("../jqwidgets/jqxpivotdesigner.js");
var core_1 = require("@angular/core");
var jqxPivotGridComponent = /** @class */ (function () {
    function jqxPivotGridComponent(containerElement) {
        var _this = this;
        this.autoCreate = true;
        this.properties = ['source', 'localization', 'scrollBarsEnabled', 'selectionEnabled', 'multipleSelectionEnabled', 'treeStyleRows', 'autoResize', 'itemsRenderer', 'cellsRenderer'];
        // jqxPivotGridComponent events
        this.onPivotitemexpanding = new core_1.EventEmitter();
        this.onPivotitemexpanded = new core_1.EventEmitter();
        this.onPivotitemcollapsing = new core_1.EventEmitter();
        this.onPivotitemcollapsed = new core_1.EventEmitter();
        this.onSortchanging = new core_1.EventEmitter();
        this.onSortchanged = new core_1.EventEmitter();
        this.onSortremoving = new core_1.EventEmitter();
        this.onSortremoved = new core_1.EventEmitter();
        this.onPivotitemselectionchanged = new core_1.EventEmitter();
        this.onPivotcellmousedown = new core_1.EventEmitter();
        this.onPivotcellmouseup = new core_1.EventEmitter();
        this.onPivotcellclick = new core_1.EventEmitter();
        this.onPivotcelldblclick = new core_1.EventEmitter();
        this.onPivotitemmousedown = new core_1.EventEmitter();
        this.onPivotitemmouseup = new core_1.EventEmitter();
        this.onPivotitemclick = new core_1.EventEmitter();
        this.onPivotitemdblclick = new core_1.EventEmitter();
        this.elementRef = containerElement;
        JQXLite(window).resize(function () {
            _this.__updateRect__();
        });
    }
    jqxPivotGridComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxPivotGridComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxPivotGrid(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxPivotGrid(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxPivotGrid(this.properties[i])) {
                        this.host.jqxPivotGrid(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxPivotGridComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxPivotGridComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxPivotGridComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxPivotGridComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxPivotGridComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxPivotGrid', options);
        this.__updateRect__();
    };
    jqxPivotGridComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxPivotGridComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
        this.refresh();
    };
    jqxPivotGridComponent.prototype.setOptions = function (options) {
        this.host.jqxPivotGrid('setOptions', options);
    };
    // jqxPivotGridComponent properties
    jqxPivotGridComponent.prototype.source = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('source', arg);
        }
        else {
            return this.host.jqxPivotGrid('source');
        }
    };
    jqxPivotGridComponent.prototype.localization = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('localization', arg);
        }
        else {
            return this.host.jqxPivotGrid('localization');
        }
    };
    jqxPivotGridComponent.prototype.scrollBarsEnabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('scrollBarsEnabled', arg);
        }
        else {
            return this.host.jqxPivotGrid('scrollBarsEnabled');
        }
    };
    jqxPivotGridComponent.prototype.selectionEnabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('selectionEnabled', arg);
        }
        else {
            return this.host.jqxPivotGrid('selectionEnabled');
        }
    };
    jqxPivotGridComponent.prototype.multipleSelectionEnabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('multipleSelectionEnabled', arg);
        }
        else {
            return this.host.jqxPivotGrid('multipleSelectionEnabled');
        }
    };
    jqxPivotGridComponent.prototype.treeStyleRows = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('treeStyleRows', arg);
        }
        else {
            return this.host.jqxPivotGrid('treeStyleRows');
        }
    };
    jqxPivotGridComponent.prototype.autoResize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('autoResize', arg);
        }
        else {
            return this.host.jqxPivotGrid('autoResize');
        }
    };
    jqxPivotGridComponent.prototype.itemsRenderer = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('itemsRenderer', arg);
        }
        else {
            return this.host.jqxPivotGrid('itemsRenderer');
        }
    };
    jqxPivotGridComponent.prototype.cellsRenderer = function (arg) {
        if (arg !== undefined) {
            this.host.jqxPivotGrid('cellsRenderer', arg);
        }
        else {
            return this.host.jqxPivotGrid('cellsRenderer');
        }
    };
    // jqxPivotGridComponent functions
    jqxPivotGridComponent.prototype.getInstance = function () {
        return this.host.jqxPivotGrid('getInstance');
    };
    jqxPivotGridComponent.prototype.refresh = function () {
        this.host.jqxPivotGrid('refresh');
    };
    jqxPivotGridComponent.prototype.getPivotRows = function () {
        return this.host.jqxPivotGrid('getPivotRows');
    };
    jqxPivotGridComponent.prototype.getPivotColumns = function () {
        return this.host.jqxPivotGrid('getPivotColumns');
    };
    jqxPivotGridComponent.prototype.getPivotCells = function () {
        return this.host.jqxPivotGrid('getPivotCells');
    };
    jqxPivotGridComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('pivotitemexpanding', function (eventData) { _this.onPivotitemexpanding.emit(eventData); });
        this.host.on('pivotitemexpanded', function (eventData) { _this.onPivotitemexpanded.emit(eventData); });
        this.host.on('pivotitemcollapsing', function (eventData) { _this.onPivotitemcollapsing.emit(eventData); });
        this.host.on('pivotitemcollapsed', function (eventData) { _this.onPivotitemcollapsed.emit(eventData); });
        this.host.on('sortchanging', function (eventData) { _this.onSortchanging.emit(eventData); });
        this.host.on('sortchanged', function (eventData) { _this.onSortchanged.emit(eventData); });
        this.host.on('sortremoving', function (eventData) { _this.onSortremoving.emit(eventData); });
        this.host.on('sortremoved', function (eventData) { _this.onSortremoved.emit(eventData); });
        this.host.on('pivotitemselectionchanged', function (eventData) { _this.onPivotitemselectionchanged.emit(eventData); });
        this.host.on('pivotcellmousedown', function (eventData) { _this.onPivotcellmousedown.emit(eventData); });
        this.host.on('pivotcellmouseup', function (eventData) { _this.onPivotcellmouseup.emit(eventData); });
        this.host.on('pivotcellclick', function (eventData) { _this.onPivotcellclick.emit(eventData); });
        this.host.on('pivotcelldblclick', function (eventData) { _this.onPivotcelldblclick.emit(eventData); });
        this.host.on('pivotitemmousedown', function (eventData) { _this.onPivotitemmousedown.emit(eventData); });
        this.host.on('pivotitemmouseup', function (eventData) { _this.onPivotitemmouseup.emit(eventData); });
        this.host.on('pivotitemclick', function (eventData) { _this.onPivotitemclick.emit(eventData); });
        this.host.on('pivotitemdblclick', function (eventData) { _this.onPivotitemdblclick.emit(eventData); });
    };
    __decorate([
        core_1.Input('source')
    ], jqxPivotGridComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('localization')
    ], jqxPivotGridComponent.prototype, "attrLocalization", void 0);
    __decorate([
        core_1.Input('scrollBarsEnabled')
    ], jqxPivotGridComponent.prototype, "attrScrollBarsEnabled", void 0);
    __decorate([
        core_1.Input('selectionEnabled')
    ], jqxPivotGridComponent.prototype, "attrSelectionEnabled", void 0);
    __decorate([
        core_1.Input('multipleSelectionEnabled')
    ], jqxPivotGridComponent.prototype, "attrMultipleSelectionEnabled", void 0);
    __decorate([
        core_1.Input('treeStyleRows')
    ], jqxPivotGridComponent.prototype, "attrTreeStyleRows", void 0);
    __decorate([
        core_1.Input('autoResize')
    ], jqxPivotGridComponent.prototype, "attrAutoResize", void 0);
    __decorate([
        core_1.Input('itemsRenderer')
    ], jqxPivotGridComponent.prototype, "attrItemsRenderer", void 0);
    __decorate([
        core_1.Input('cellsRenderer')
    ], jqxPivotGridComponent.prototype, "attrCellsRenderer", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxPivotGridComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxPivotGridComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxPivotGridComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemexpanding", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemexpanded", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemcollapsing", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemcollapsed", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onSortchanging", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onSortchanged", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onSortremoving", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onSortremoved", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemselectionchanged", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotcellmousedown", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotcellmouseup", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotcellclick", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotcelldblclick", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemmousedown", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemmouseup", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemclick", void 0);
    __decorate([
        core_1.Output()
    ], jqxPivotGridComponent.prototype, "onPivotitemdblclick", void 0);
    jqxPivotGridComponent = __decorate([
        core_1.Component({
            selector: 'jqxPivotGrid',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxPivotGridComponent);
    return jqxPivotGridComponent;
}()); //jqxPivotGridComponent
exports.jqxPivotGridComponent = jqxPivotGridComponent;
