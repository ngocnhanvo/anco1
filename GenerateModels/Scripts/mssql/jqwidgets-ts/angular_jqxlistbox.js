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
require("../jqwidgets/jqxdragdrop.js");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var noop = function () { };
var CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR = {
    provide: forms_1.NG_VALUE_ACCESSOR,
    useExisting: core_1.forwardRef(function () { return jqxListBoxComponent; }),
    multi: true
};
var jqxListBoxComponent = /** @class */ (function () {
    function jqxListBoxComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['autoHeight', 'allowDrag', 'allowDrop', 'checkboxes', 'disabled', 'displayMember', 'dropAction', 'dragStart', 'dragEnd', 'enableHover', 'enableSelection', 'equalItemsWidth', 'filterable', 'filterHeight', 'filterDelay', 'filterPlaceHolder', 'height', 'hasThreeStates', 'itemHeight', 'incrementalSearch', 'incrementalSearchDelay', 'multiple', 'multipleextended', 'renderer', 'rendered', 'rtl', 'selectedIndex', 'selectedIndexes', 'source', 'scrollBarSize', 'searchMode', 'theme', 'valueMember', 'width'];
        this.onTouchedCallback = noop;
        this.onChangeCallback = noop;
        // jqxListBoxComponent events
        this.onBindingComplete = new core_1.EventEmitter();
        this.onChange = new core_1.EventEmitter();
        this.onCheckChange = new core_1.EventEmitter();
        this.onDragStart = new core_1.EventEmitter();
        this.onDragEnd = new core_1.EventEmitter();
        this.onSelect = new core_1.EventEmitter();
        this.onUnselect = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxListBoxComponent.prototype.ngOnInit = function () {
    };
    ;
    jqxListBoxComponent.prototype.ngAfterViewInit = function () {
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
    jqxListBoxComponent.prototype.ngAfterViewChecked = function () {
        if (typeof JQXLite === 'undefined') {
            return;
        }
        if (this.container) {
            if (this.content !== this.container.innerHTML) {
                this.content = this.container.innerHTML;
                var result = JQXLite.jqx.parseSourceTag(this.container);
                this.host.jqxListBox({ source: result.items });
            }
        }
    };
    ;
    jqxListBoxComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxListBox(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxListBox(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxListBox(this.properties[i])) {
                        this.host.jqxListBox(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxListBoxComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxListBoxComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxListBoxComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxListBoxComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxListBoxComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxListBox', options);
    };
    jqxListBoxComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxListBoxComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxListBoxComponent.prototype.writeValue = function (value) {
        if (this.widgetObject) {
            this.onChangeCallback(this.host.val());
            this.widgetObject.clearSelection();
            if (value) {
                this.widgetObject.selectItem(this.widgetObject.getItemByValue(value));
            }
        }
        if (this.host && (value === null || value === undefined)) {
            this.host.jqxListBox('val', '');
        }
    };
    jqxListBoxComponent.prototype.registerOnChange = function (fn) {
        this.onChangeCallback = fn;
    };
    jqxListBoxComponent.prototype.registerOnTouched = function (fn) {
        this.onTouchedCallback = fn;
    };
    jqxListBoxComponent.prototype.setOptions = function (options) {
        this.host.jqxListBox('setOptions', options);
    };
    // jqxListBoxComponent properties
    jqxListBoxComponent.prototype.autoHeight = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('autoHeight', arg);
        }
        else {
            return this.host.jqxListBox('autoHeight');
        }
    };
    jqxListBoxComponent.prototype.allowDrag = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('allowDrag', arg);
        }
        else {
            return this.host.jqxListBox('allowDrag');
        }
    };
    jqxListBoxComponent.prototype.allowDrop = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('allowDrop', arg);
        }
        else {
            return this.host.jqxListBox('allowDrop');
        }
    };
    jqxListBoxComponent.prototype.checkboxes = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('checkboxes', arg);
        }
        else {
            return this.host.jqxListBox('checkboxes');
        }
    };
    jqxListBoxComponent.prototype.disabled = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('disabled', arg);
        }
        else {
            return this.host.jqxListBox('disabled');
        }
    };
    jqxListBoxComponent.prototype.displayMember = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('displayMember', arg);
        }
        else {
            return this.host.jqxListBox('displayMember');
        }
    };
    jqxListBoxComponent.prototype.dropAction = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('dropAction', arg);
        }
        else {
            return this.host.jqxListBox('dropAction');
        }
    };
    jqxListBoxComponent.prototype.dragStart = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('dragStart', arg);
        }
        else {
            return this.host.jqxListBox('dragStart');
        }
    };
    jqxListBoxComponent.prototype.dragEnd = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('dragEnd', arg);
        }
        else {
            return this.host.jqxListBox('dragEnd');
        }
    };
    jqxListBoxComponent.prototype.enableHover = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('enableHover', arg);
        }
        else {
            return this.host.jqxListBox('enableHover');
        }
    };
    jqxListBoxComponent.prototype.enableSelection = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('enableSelection', arg);
        }
        else {
            return this.host.jqxListBox('enableSelection');
        }
    };
    jqxListBoxComponent.prototype.equalItemsWidth = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('equalItemsWidth', arg);
        }
        else {
            return this.host.jqxListBox('equalItemsWidth');
        }
    };
    jqxListBoxComponent.prototype.filterable = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('filterable', arg);
        }
        else {
            return this.host.jqxListBox('filterable');
        }
    };
    jqxListBoxComponent.prototype.filterHeight = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('filterHeight', arg);
        }
        else {
            return this.host.jqxListBox('filterHeight');
        }
    };
    jqxListBoxComponent.prototype.filterDelay = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('filterDelay', arg);
        }
        else {
            return this.host.jqxListBox('filterDelay');
        }
    };
    jqxListBoxComponent.prototype.filterPlaceHolder = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('filterPlaceHolder', arg);
        }
        else {
            return this.host.jqxListBox('filterPlaceHolder');
        }
    };
    jqxListBoxComponent.prototype.height = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('height', arg);
        }
        else {
            return this.host.jqxListBox('height');
        }
    };
    jqxListBoxComponent.prototype.hasThreeStates = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('hasThreeStates', arg);
        }
        else {
            return this.host.jqxListBox('hasThreeStates');
        }
    };
    jqxListBoxComponent.prototype.itemHeight = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('itemHeight', arg);
        }
        else {
            return this.host.jqxListBox('itemHeight');
        }
    };
    jqxListBoxComponent.prototype.incrementalSearch = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('incrementalSearch', arg);
        }
        else {
            return this.host.jqxListBox('incrementalSearch');
        }
    };
    jqxListBoxComponent.prototype.incrementalSearchDelay = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('incrementalSearchDelay', arg);
        }
        else {
            return this.host.jqxListBox('incrementalSearchDelay');
        }
    };
    jqxListBoxComponent.prototype.multiple = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('multiple', arg);
        }
        else {
            return this.host.jqxListBox('multiple');
        }
    };
    jqxListBoxComponent.prototype.multipleextended = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('multipleextended', arg);
        }
        else {
            return this.host.jqxListBox('multipleextended');
        }
    };
    jqxListBoxComponent.prototype.renderer = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('renderer', arg);
        }
        else {
            return this.host.jqxListBox('renderer');
        }
    };
    jqxListBoxComponent.prototype.rendered = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('rendered', arg);
        }
        else {
            return this.host.jqxListBox('rendered');
        }
    };
    jqxListBoxComponent.prototype.rtl = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('rtl', arg);
        }
        else {
            return this.host.jqxListBox('rtl');
        }
    };
    jqxListBoxComponent.prototype.selectedIndex = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('selectedIndex', arg);
        }
        else {
            return this.host.jqxListBox('selectedIndex');
        }
    };
    jqxListBoxComponent.prototype.selectedIndexes = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('selectedIndexes', arg);
        }
        else {
            return this.host.jqxListBox('selectedIndexes');
        }
    };
    jqxListBoxComponent.prototype.source = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('source', arg);
        }
        else {
            return this.host.jqxListBox('source');
        }
    };
    jqxListBoxComponent.prototype.scrollBarSize = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('scrollBarSize', arg);
        }
        else {
            return this.host.jqxListBox('scrollBarSize');
        }
    };
    jqxListBoxComponent.prototype.searchMode = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('searchMode', arg);
        }
        else {
            return this.host.jqxListBox('searchMode');
        }
    };
    jqxListBoxComponent.prototype.theme = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('theme', arg);
        }
        else {
            return this.host.jqxListBox('theme');
        }
    };
    jqxListBoxComponent.prototype.valueMember = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('valueMember', arg);
        }
        else {
            return this.host.jqxListBox('valueMember');
        }
    };
    jqxListBoxComponent.prototype.width = function (arg) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        if (arg !== undefined) {
            this.host.jqxListBox('width', arg);
        }
        else {
            return this.host.jqxListBox('width');
        }
    };
    // jqxListBoxComponent functions
    jqxListBoxComponent.prototype.addItem = function (Item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxListBox('addItem', Item);
    };
    jqxListBoxComponent.prototype.beginUpdate = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('beginUpdate');
    };
    jqxListBoxComponent.prototype.clear = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('clear');
    };
    jqxListBoxComponent.prototype.clearSelection = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('clearSelection');
    };
    jqxListBoxComponent.prototype.checkIndex = function (Index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('checkIndex', Index);
    };
    jqxListBoxComponent.prototype.checkItem = function (Item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('checkItem', Item);
    };
    jqxListBoxComponent.prototype.checkAll = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('checkAll');
    };
    jqxListBoxComponent.prototype.clearFilter = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('clearFilter');
    };
    jqxListBoxComponent.prototype.destroy = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('destroy');
    };
    jqxListBoxComponent.prototype.disableItem = function (Item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('disableItem', Item);
    };
    jqxListBoxComponent.prototype.disableAt = function (Index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('disableAt', Index);
    };
    jqxListBoxComponent.prototype.enableItem = function (Item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('enableItem', Item);
    };
    jqxListBoxComponent.prototype.enableAt = function (Index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('enableAt', Index);
    };
    jqxListBoxComponent.prototype.ensureVisible = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('ensureVisible', item);
    };
    jqxListBoxComponent.prototype.endUpdate = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('endUpdate');
    };
    jqxListBoxComponent.prototype.focus = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('focus');
    };
    jqxListBoxComponent.prototype.getItems = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxListBox('getItems');
    };
    jqxListBoxComponent.prototype.getSelectedItems = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxListBox('getSelectedItems');
    };
    jqxListBoxComponent.prototype.getCheckedItems = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxListBox('getCheckedItems');
    };
    jqxListBoxComponent.prototype.getItem = function (Index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxListBox('getItem', Index);
    };
    jqxListBoxComponent.prototype.getItemByValue = function (Item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxListBox('getItemByValue', Item);
    };
    jqxListBoxComponent.prototype.getSelectedItem = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxListBox('getSelectedItem');
    };
    jqxListBoxComponent.prototype.getSelectedIndex = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        return this.host.jqxListBox('getSelectedIndex');
    };
    jqxListBoxComponent.prototype.insertAt = function (Item, Index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('insertAt', Item, Index);
    };
    jqxListBoxComponent.prototype.invalidate = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('invalidate');
    };
    jqxListBoxComponent.prototype.indeterminateItem = function (Item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('indeterminateItem', Item);
    };
    jqxListBoxComponent.prototype.indeterminateIndex = function (Index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('indeterminateIndex', Index);
    };
    jqxListBoxComponent.prototype.loadFromSelect = function (selector) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('loadFromSelect', selector);
    };
    jqxListBoxComponent.prototype.removeItem = function (Item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('removeItem', Item);
    };
    jqxListBoxComponent.prototype.removeAt = function (Index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('removeAt', Index);
    };
    jqxListBoxComponent.prototype.render = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('render');
    };
    jqxListBoxComponent.prototype.refresh = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('refresh');
    };
    jqxListBoxComponent.prototype.selectItem = function (Item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('selectItem', Item);
    };
    jqxListBoxComponent.prototype.selectIndex = function (Index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('selectIndex', Index);
    };
    jqxListBoxComponent.prototype.updateItem = function (Item, Value) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('updateItem', Item, Value);
    };
    jqxListBoxComponent.prototype.updateAt = function (item, index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('updateAt', item, index);
    };
    jqxListBoxComponent.prototype.unselectIndex = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('unselectIndex', index);
    };
    jqxListBoxComponent.prototype.unselectItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('unselectItem', item);
    };
    jqxListBoxComponent.prototype.uncheckIndex = function (index) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('uncheckIndex', index);
    };
    jqxListBoxComponent.prototype.uncheckItem = function (item) {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('uncheckItem', item);
    };
    jqxListBoxComponent.prototype.uncheckAll = function () {
        if (this.autoCreate && !this.host) {
            this.createComponent();
        }
        this.host.jqxListBox('uncheckAll');
    };
    jqxListBoxComponent.prototype.val = function (value) {
        if (value !== undefined) {
            return this.host.jqxListBox('val', value);
        }
        else {
            return this.host.jqxListBox('val');
        }
    };
    ;
    jqxListBoxComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('bindingComplete', function (eventData) { _this.onBindingComplete.emit(eventData); });
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); if (eventData.args)
            _this.onChangeCallback(eventData.args.item.value); });
        this.host.on('checkChange', function (eventData) { _this.onCheckChange.emit(eventData); });
        this.host.on('dragStart', function (eventData) { _this.onDragStart.emit(eventData); });
        this.host.on('dragEnd', function (eventData) { _this.onDragEnd.emit(eventData); });
        this.host.on('select', function (eventData) { _this.onSelect.emit(eventData); });
        this.host.on('unselect', function (eventData) { _this.onUnselect.emit(eventData); });
    };
    __decorate([
        core_1.Input('autoHeight')
    ], jqxListBoxComponent.prototype, "attrAutoHeight", void 0);
    __decorate([
        core_1.Input('allowDrag')
    ], jqxListBoxComponent.prototype, "attrAllowDrag", void 0);
    __decorate([
        core_1.Input('allowDrop')
    ], jqxListBoxComponent.prototype, "attrAllowDrop", void 0);
    __decorate([
        core_1.Input('checkboxes')
    ], jqxListBoxComponent.prototype, "attrCheckboxes", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxListBoxComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('displayMember')
    ], jqxListBoxComponent.prototype, "attrDisplayMember", void 0);
    __decorate([
        core_1.Input('dropAction')
    ], jqxListBoxComponent.prototype, "attrDropAction", void 0);
    __decorate([
        core_1.Input('dragStart')
    ], jqxListBoxComponent.prototype, "attrDragStart", void 0);
    __decorate([
        core_1.Input('dragEnd')
    ], jqxListBoxComponent.prototype, "attrDragEnd", void 0);
    __decorate([
        core_1.Input('enableHover')
    ], jqxListBoxComponent.prototype, "attrEnableHover", void 0);
    __decorate([
        core_1.Input('enableSelection')
    ], jqxListBoxComponent.prototype, "attrEnableSelection", void 0);
    __decorate([
        core_1.Input('equalItemsWidth')
    ], jqxListBoxComponent.prototype, "attrEqualItemsWidth", void 0);
    __decorate([
        core_1.Input('filterable')
    ], jqxListBoxComponent.prototype, "attrFilterable", void 0);
    __decorate([
        core_1.Input('filterHeight')
    ], jqxListBoxComponent.prototype, "attrFilterHeight", void 0);
    __decorate([
        core_1.Input('filterDelay')
    ], jqxListBoxComponent.prototype, "attrFilterDelay", void 0);
    __decorate([
        core_1.Input('filterPlaceHolder')
    ], jqxListBoxComponent.prototype, "attrFilterPlaceHolder", void 0);
    __decorate([
        core_1.Input('hasThreeStates')
    ], jqxListBoxComponent.prototype, "attrHasThreeStates", void 0);
    __decorate([
        core_1.Input('itemHeight')
    ], jqxListBoxComponent.prototype, "attrItemHeight", void 0);
    __decorate([
        core_1.Input('incrementalSearch')
    ], jqxListBoxComponent.prototype, "attrIncrementalSearch", void 0);
    __decorate([
        core_1.Input('incrementalSearchDelay')
    ], jqxListBoxComponent.prototype, "attrIncrementalSearchDelay", void 0);
    __decorate([
        core_1.Input('multiple')
    ], jqxListBoxComponent.prototype, "attrMultiple", void 0);
    __decorate([
        core_1.Input('multipleextended')
    ], jqxListBoxComponent.prototype, "attrMultipleextended", void 0);
    __decorate([
        core_1.Input('renderer')
    ], jqxListBoxComponent.prototype, "attrRenderer", void 0);
    __decorate([
        core_1.Input('rendered')
    ], jqxListBoxComponent.prototype, "attrRendered", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxListBoxComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('selectedIndex')
    ], jqxListBoxComponent.prototype, "attrSelectedIndex", void 0);
    __decorate([
        core_1.Input('selectedIndexes')
    ], jqxListBoxComponent.prototype, "attrSelectedIndexes", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxListBoxComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('scrollBarSize')
    ], jqxListBoxComponent.prototype, "attrScrollBarSize", void 0);
    __decorate([
        core_1.Input('searchMode')
    ], jqxListBoxComponent.prototype, "attrSearchMode", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxListBoxComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('valueMember')
    ], jqxListBoxComponent.prototype, "attrValueMember", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxListBoxComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxListBoxComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxListBoxComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxListBoxComponent.prototype, "onBindingComplete", void 0);
    __decorate([
        core_1.Output()
    ], jqxListBoxComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxListBoxComponent.prototype, "onCheckChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxListBoxComponent.prototype, "onDragStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxListBoxComponent.prototype, "onDragEnd", void 0);
    __decorate([
        core_1.Output()
    ], jqxListBoxComponent.prototype, "onSelect", void 0);
    __decorate([
        core_1.Output()
    ], jqxListBoxComponent.prototype, "onUnselect", void 0);
    jqxListBoxComponent = __decorate([
        core_1.Component({
            selector: 'jqxListBox',
            template: '<div><ng-content></ng-content></div>',
            providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR],
            changeDetection: core_1.ChangeDetectionStrategy.OnPush
        })
    ], jqxListBoxComponent);
    return jqxListBoxComponent;
}()); //jqxListBoxComponent
exports.jqxListBoxComponent = jqxListBoxComponent;
