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
require("../jqwidgets/jqxlistbox.js");
require("../jqwidgets/jqxdropdownlist.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxDropDownListComponent; }),
    multi: true
};
var jqxDropDownListComponent = /** @class */ (function () {
    function jqxDropDownListComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['autoOpen', 'autoDropDownHeight', 'animationType', 'checkboxes', 'closeDelay', 'disabled', 'displayMember', 'dropDownHorizontalAlignment', 'dropDownVerticalAlignment', 'dropDownHeight', 'dropDownWidth', 'enableSelection', 'enableBrowserBoundsDetection', 'enableHover', 'filterable', 'filterHeight', 'filterDelay', 'filterPlaceHolder', 'height', 'incrementalSearch', 'incrementalSearchDelay', 'itemHeight', 'openDelay', 'placeHolder', 'popupZIndex', 'rtl', 'renderer', 'selectionRenderer', 'searchMode', 'source', 'selectedIndex', 'scrollBarSize', 'theme', 'template', 'valueMember', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxDropDownListComponent events
        this.onBindingComplete = new core_1.EventEmitter();
        this.onClose = new core_1.EventEmitter();
        this.onCheckChange = new core_1.EventEmitter();
        this.onChange = new core_1.EventEmitter();
        this.onOpen = new core_1.EventEmitter();
        this.onSelect = new core_1.EventEmitter();
        this.onUnselect = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxDropDownListComponent.prototype.ngOnInit = function () {
    };
    ;
    jqxDropDownListComponent.prototype.ngAfterViewInit = function () {
        var children = JQXLite(this.elementRef.nativeElement.children).find('li');
        var html = '';
        var options = {};
        if (children.length > 0) {
            this.container = document.createElement('div');
            html = this.elementRef.nativeElement.innerHTML;
            this.container.appendChild(this.elementRef.nativeElement.firstChild);
            this.elementRef.nativeElement.innerHTML = html;
            this.content = html;
            var result = JQXLite.jqx.parseSourceTag(this.container);
            options['source'] = result.items;
        }
        if (this.autoCreate) {
            this.createComponent(options);
        }
    };
    ;
    jqxDropDownListComponent.prototype.ngAfterViewChecked = function () {
        if (typeof JQXLite === 'undefined') {
            return;
        }
        if (this.container) {
            if (this.content !== this.container.innerHTML) {
                this.content = this.container.innerHTML;
                var result = JQXLite.jqx.parseSourceTag(this.container);
                this.host.jqxDropDownList({ source: result.items });
            }
        }
    };
    ;
    jqxDropDownListComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxDropDownList(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxDropDownList(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxDropDownList(this.properties[i])) {
                        this.host.jqxDropDownList(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxDropDownListComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxDropDownListComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxDropDownListComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxDropDownListComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxDropDownListComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxDropDownList', options);
    };
    jqxDropDownListComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxDropDownListComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxDropDownListComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.onChangeCallback(this.host.val());
            this.widgetObject.clearSelection();
            if (value) {
                this.widgetObject.selectItem(this.widgetObject.getItemByValue(value));
            }
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxDropDownList('val', '');
        }
    };
    jqxDropDownListComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxDropDownListComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxDropDownListComponent.prototype.setOptions = function (options) {
        this.host.jqxDropDownList('setOptions', options);
    };
    // jqxDropDownListComponent properties
    jqxDropDownListComponent.prototype.autoOpen = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('autoOpen', arg);
        }
        else {
            return this.host.jqxDropDownList('autoOpen');
        }
    };
    jqxDropDownListComponent.prototype.autoDropDownHeight = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('autoDropDownHeight', arg);
        }
        else {
            return this.host.jqxDropDownList('autoDropDownHeight');
        }
    };
    jqxDropDownListComponent.prototype.animationType = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('animationType', arg);
        }
        else {
            return this.host.jqxDropDownList('animationType');
        }
    };
    jqxDropDownListComponent.prototype.checkboxes = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('checkboxes', arg);
        }
        else {
            return this.host.jqxDropDownList('checkboxes');
        }
    };
    jqxDropDownListComponent.prototype.closeDelay = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('closeDelay', arg);
        }
        else {
            return this.host.jqxDropDownList('closeDelay');
        }
    };
    jqxDropDownListComponent.prototype.disabled = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('disabled', arg);
        }
        else {
            return this.host.jqxDropDownList('disabled');
        }
    };
    jqxDropDownListComponent.prototype.displayMember = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('displayMember', arg);
        }
        else {
            return this.host.jqxDropDownList('displayMember');
        }
    };
    jqxDropDownListComponent.prototype.dropDownHorizontalAlignment = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('dropDownHorizontalAlignment', arg);
        }
        else {
            return this.host.jqxDropDownList('dropDownHorizontalAlignment');
        }
    };
    jqxDropDownListComponent.prototype.dropDownVerticalAlignment = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('dropDownVerticalAlignment', arg);
        }
        else {
            return this.host.jqxDropDownList('dropDownVerticalAlignment');
        }
    };
    jqxDropDownListComponent.prototype.dropDownHeight = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('dropDownHeight', arg);
        }
        else {
            return this.host.jqxDropDownList('dropDownHeight');
        }
    };
    jqxDropDownListComponent.prototype.dropDownWidth = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('dropDownWidth', arg);
        }
        else {
            return this.host.jqxDropDownList('dropDownWidth');
        }
    };
    jqxDropDownListComponent.prototype.enableSelection = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('enableSelection', arg);
        }
        else {
            return this.host.jqxDropDownList('enableSelection');
        }
    };
    jqxDropDownListComponent.prototype.enableBrowserBoundsDetection = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('enableBrowserBoundsDetection', arg);
        }
        else {
            return this.host.jqxDropDownList('enableBrowserBoundsDetection');
        }
    };
    jqxDropDownListComponent.prototype.enableHover = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('enableHover', arg);
        }
        else {
            return this.host.jqxDropDownList('enableHover');
        }
    };
    jqxDropDownListComponent.prototype.filterable = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('filterable', arg);
        }
        else {
            return this.host.jqxDropDownList('filterable');
        }
    };
    jqxDropDownListComponent.prototype.filterHeight = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('filterHeight', arg);
        }
        else {
            return this.host.jqxDropDownList('filterHeight');
        }
    };
    jqxDropDownListComponent.prototype.filterDelay = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('filterDelay', arg);
        }
        else {
            return this.host.jqxDropDownList('filterDelay');
        }
    };
    jqxDropDownListComponent.prototype.filterPlaceHolder = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('filterPlaceHolder', arg);
        }
        else {
            return this.host.jqxDropDownList('filterPlaceHolder');
        }
    };
    jqxDropDownListComponent.prototype.height = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('height', arg);
        }
        else {
            return this.host.jqxDropDownList('height');
        }
    };
    jqxDropDownListComponent.prototype.incrementalSearch = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('incrementalSearch', arg);
        }
        else {
            return this.host.jqxDropDownList('incrementalSearch');
        }
    };
    jqxDropDownListComponent.prototype.incrementalSearchDelay = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('incrementalSearchDelay', arg);
        }
        else {
            return this.host.jqxDropDownList('incrementalSearchDelay');
        }
    };
    jqxDropDownListComponent.prototype.itemHeight = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('itemHeight', arg);
        }
        else {
            return this.host.jqxDropDownList('itemHeight');
        }
    };
    jqxDropDownListComponent.prototype.openDelay = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('openDelay', arg);
        }
        else {
            return this.host.jqxDropDownList('openDelay');
        }
    };
    jqxDropDownListComponent.prototype.placeHolder = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('placeHolder', arg);
        }
        else {
            return this.host.jqxDropDownList('placeHolder');
        }
    };
    jqxDropDownListComponent.prototype.popupZIndex = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('popupZIndex', arg);
        }
        else {
            return this.host.jqxDropDownList('popupZIndex');
        }
    };
    jqxDropDownListComponent.prototype.rtl = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('rtl', arg);
        }
        else {
            return this.host.jqxDropDownList('rtl');
        }
    };
    jqxDropDownListComponent.prototype.renderer = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('renderer', arg);
        }
        else {
            return this.host.jqxDropDownList('renderer');
        }
    };
    jqxDropDownListComponent.prototype.selectionRenderer = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('selectionRenderer', arg);
        }
        else {
            return this.host.jqxDropDownList('selectionRenderer');
        }
    };
    jqxDropDownListComponent.prototype.searchMode = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('searchMode', arg);
        }
        else {
            return this.host.jqxDropDownList('searchMode');
        }
    };
    jqxDropDownListComponent.prototype.source = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('source', arg);
        }
        else {
            return this.host.jqxDropDownList('source');
        }
    };
    jqxDropDownListComponent.prototype.selectedIndex = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('selectedIndex', arg);
        }
        else {
            return this.host.jqxDropDownList('selectedIndex');
        }
    };
    jqxDropDownListComponent.prototype.scrollBarSize = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('scrollBarSize', arg);
        }
        else {
            return this.host.jqxDropDownList('scrollBarSize');
        }
    };
    jqxDropDownListComponent.prototype.theme = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('theme', arg);
        }
        else {
            return this.host.jqxDropDownList('theme');
        }
    };
    jqxDropDownListComponent.prototype.template = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('template', arg);
        }
        else {
            return this.host.jqxDropDownList('template');
        }
    };
    jqxDropDownListComponent.prototype.valueMember = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('valueMember', arg);
        }
        else {
            return this.host.jqxDropDownList('valueMember');
        }
    };
    jqxDropDownListComponent.prototype.width = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxDropDownList('width', arg);
        }
        else {
            return this.host.jqxDropDownList('width');
        }
    };
    // jqxDropDownListComponent functions
    jqxDropDownListComponent.prototype.addItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxDropDownList('addItem', item);
    };
    jqxDropDownListComponent.prototype.clearSelection = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('clearSelection');
    };
    jqxDropDownListComponent.prototype.clear = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('clear');
    };
    jqxDropDownListComponent.prototype.close = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('close');
    };
    jqxDropDownListComponent.prototype.checkIndex = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('checkIndex', index);
    };
    jqxDropDownListComponent.prototype.checkItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('checkItem', item);
    };
    jqxDropDownListComponent.prototype.checkAll = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('checkAll');
    };
    jqxDropDownListComponent.prototype.clearFilter = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('clearFilter');
    };
    jqxDropDownListComponent.prototype.destroy = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('destroy');
    };
    jqxDropDownListComponent.prototype.disableItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('disableItem', item);
    };
    jqxDropDownListComponent.prototype.disableAt = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('disableAt', index);
    };
    jqxDropDownListComponent.prototype.enableItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('enableItem', item);
    };
    jqxDropDownListComponent.prototype.enableAt = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('enableAt', index);
    };
    jqxDropDownListComponent.prototype.ensureVisible = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('ensureVisible', index);
    };
    jqxDropDownListComponent.prototype.focus = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('focus');
    };
    jqxDropDownListComponent.prototype.getItem = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxDropDownList('getItem', index);
    };
    jqxDropDownListComponent.prototype.getItemByValue = function (itemValue) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxDropDownList('getItemByValue', itemValue);
    };
    jqxDropDownListComponent.prototype.getItems = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxDropDownList('getItems');
    };
    jqxDropDownListComponent.prototype.getCheckedItems = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxDropDownList('getCheckedItems');
    };
    jqxDropDownListComponent.prototype.getSelectedItem = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxDropDownList('getSelectedItem');
    };
    jqxDropDownListComponent.prototype.getSelectedIndex = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxDropDownList('getSelectedIndex');
    };
    jqxDropDownListComponent.prototype.insertAt = function (item, index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('insertAt', item, index);
    };
    jqxDropDownListComponent.prototype.isOpened = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxDropDownList('isOpened');
    };
    jqxDropDownListComponent.prototype.indeterminateIndex = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('indeterminateIndex', index);
    };
    jqxDropDownListComponent.prototype.indeterminateItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('indeterminateItem', item);
    };
    jqxDropDownListComponent.prototype.loadFromSelect = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('loadFromSelect', arg);
    };
    jqxDropDownListComponent.prototype.open = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('open');
    };
    jqxDropDownListComponent.prototype.removeItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('removeItem', item);
    };
    jqxDropDownListComponent.prototype.removeAt = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('removeAt', index);
    };
    jqxDropDownListComponent.prototype.selectIndex = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('selectIndex', index);
    };
    jqxDropDownListComponent.prototype.selectItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('selectItem', item);
    };
    jqxDropDownListComponent.prototype.setContent = function (content) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('setContent', content);
    };
    jqxDropDownListComponent.prototype.updateItem = function (newItem, item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('updateItem', newItem, item);
    };
    jqxDropDownListComponent.prototype.updateAt = function (item, index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('updateAt', item, index);
    };
    jqxDropDownListComponent.prototype.unselectIndex = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('unselectIndex', index);
    };
    jqxDropDownListComponent.prototype.unselectItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('unselectItem', item);
    };
    jqxDropDownListComponent.prototype.uncheckIndex = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('uncheckIndex', index);
    };
    jqxDropDownListComponent.prototype.uncheckItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('uncheckItem', item);
    };
    jqxDropDownListComponent.prototype.uncheckAll = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxDropDownList('uncheckAll');
    };
    jqxDropDownListComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxDropDownList('val', value);
        }
        else {
            return this.host.jqxDropDownList('val');
        }
    };
    ;
    jqxDropDownListComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('bindingComplete', function (eventData) { _this.onBindingComplete.emit(eventData); });
        this.host.on('close', function (eventData) { _this.onClose.emit(eventData); });
        this.host.on('checkChange', function (eventData) { _this.onCheckChange.emit(eventData); });
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.item.value); });
        this.host.on('open', function (eventData) { _this.onOpen.emit(eventData); });
        this.host.on('select', function (eventData) { _this.onSelect.emit(eventData); });
        this.host.on('unselect', function (eventData) { _this.onUnselect.emit(eventData); });
    };
    __decorate([
        core_1.Input('autoOpen')
    ], jqxDropDownListComponent.prototype, "attrAutoOpen", void 0);
    __decorate([
        core_1.Input('autoDropDownHeight')
    ], jqxDropDownListComponent.prototype, "attrAutoDropDownHeight", void 0);
    __decorate([
        core_1.Input('animationType')
    ], jqxDropDownListComponent.prototype, "attrAnimationType", void 0);
    __decorate([
        core_1.Input('checkboxes')
    ], jqxDropDownListComponent.prototype, "attrCheckboxes", void 0);
    __decorate([
        core_1.Input('closeDelay')
    ], jqxDropDownListComponent.prototype, "attrCloseDelay", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxDropDownListComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('displayMember')
    ], jqxDropDownListComponent.prototype, "attrDisplayMember", void 0);
    __decorate([
        core_1.Input('dropDownHorizontalAlignment')
    ], jqxDropDownListComponent.prototype, "attrDropDownHorizontalAlignment", void 0);
    __decorate([
        core_1.Input('dropDownVerticalAlignment')
    ], jqxDropDownListComponent.prototype, "attrDropDownVerticalAlignment", void 0);
    __decorate([
        core_1.Input('dropDownHeight')
    ], jqxDropDownListComponent.prototype, "attrDropDownHeight", void 0);
    __decorate([
        core_1.Input('dropDownWidth')
    ], jqxDropDownListComponent.prototype, "attrDropDownWidth", void 0);
    __decorate([
        core_1.Input('enableSelection')
    ], jqxDropDownListComponent.prototype, "attrEnableSelection", void 0);
    __decorate([
        core_1.Input('enableBrowserBoundsDetection')
    ], jqxDropDownListComponent.prototype, "attrEnableBrowserBoundsDetection", void 0);
    __decorate([
        core_1.Input('enableHover')
    ], jqxDropDownListComponent.prototype, "attrEnableHover", void 0);
    __decorate([
        core_1.Input('filterable')
    ], jqxDropDownListComponent.prototype, "attrFilterable", void 0);
    __decorate([
        core_1.Input('filterHeight')
    ], jqxDropDownListComponent.prototype, "attrFilterHeight", void 0);
    __decorate([
        core_1.Input('filterDelay')
    ], jqxDropDownListComponent.prototype, "attrFilterDelay", void 0);
    __decorate([
        core_1.Input('filterPlaceHolder')
    ], jqxDropDownListComponent.prototype, "attrFilterPlaceHolder", void 0);
    __decorate([
        core_1.Input('incrementalSearch')
    ], jqxDropDownListComponent.prototype, "attrIncrementalSearch", void 0);
    __decorate([
        core_1.Input('incrementalSearchDelay')
    ], jqxDropDownListComponent.prototype, "attrIncrementalSearchDelay", void 0);
    __decorate([
        core_1.Input('itemHeight')
    ], jqxDropDownListComponent.prototype, "attrItemHeight", void 0);
    __decorate([
        core_1.Input('openDelay')
    ], jqxDropDownListComponent.prototype, "attrOpenDelay", void 0);
    __decorate([
        core_1.Input('placeHolder')
    ], jqxDropDownListComponent.prototype, "attrPlaceHolder", void 0);
    __decorate([
        core_1.Input('popupZIndex')
    ], jqxDropDownListComponent.prototype, "attrPopupZIndex", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxDropDownListComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('renderer')
    ], jqxDropDownListComponent.prototype, "attrRenderer", void 0);
    __decorate([
        core_1.Input('selectionRenderer')
    ], jqxDropDownListComponent.prototype, "attrSelectionRenderer", void 0);
    __decorate([
        core_1.Input('searchMode')
    ], jqxDropDownListComponent.prototype, "attrSearchMode", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxDropDownListComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('selectedIndex')
    ], jqxDropDownListComponent.prototype, "attrSelectedIndex", void 0);
    __decorate([
        core_1.Input('scrollBarSize')
    ], jqxDropDownListComponent.prototype, "attrScrollBarSize", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxDropDownListComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('template')
    ], jqxDropDownListComponent.prototype, "attrTemplate", void 0);
    __decorate([
        core_1.Input('valueMember')
    ], jqxDropDownListComponent.prototype, "attrValueMember", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxDropDownListComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxDropDownListComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxDropDownListComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxDropDownListComponent.prototype, "onBindingComplete", void 0);
    __decorate([
        core_1.Output()
    ], jqxDropDownListComponent.prototype, "onClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxDropDownListComponent.prototype, "onCheckChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxDropDownListComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxDropDownListComponent.prototype, "onOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxDropDownListComponent.prototype, "onSelect", void 0);
    __decorate([
        core_1.Output()
    ], jqxDropDownListComponent.prototype, "onUnselect", void 0);
    jqxDropDownListComponent = __decorate([
        core_1.Component({
            selector: 'jqxDropDownList',
            template: '<div><ng-content></ng-content></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxDropDownListComponent);
    return jqxDropDownListComponent;
}()); //jqxDropDownListComponent
exports.jqxDropDownListComponent = jqxDropDownListComponent;
