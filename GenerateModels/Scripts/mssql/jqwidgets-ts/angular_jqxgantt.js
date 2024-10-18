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
require("../jqwidgets/jqxgantt.api.js");
require("../jqwidgets/jqxgantt.js");
var core_1 = require("@angular/core");
var jqxGanttComponent = /** @class */ (function () {
    function jqxGanttComponent(containerElement) {
        var _this = this;
        this.autoCreate = true;
        this.properties = ['adjustToNonworkingTime', 'autoSchedule', 'autoScheduleStrictMode', 'autoScrollStep', 'columnMenu', 'columnMinWidth', 'columnResize', 'columnResizeFeedback', 'currentTime', 'currentTimeIndicator', 'currentTimeIndicatorInterval', 'dataExportFileName', 'source', 'dayFormat', 'dateEnd', 'dateStart', 'dateMarkers', 'disabled', 'disableAutoScroll', 'disableTaskDrag', 'disableTaskProgressChange', 'disableTaskResize', 'disableSelection', 'disableSegmentDrag', 'disableSegmentResize', 'disableWindowEditor', 'durationUnit', 'filterRow', 'firstDayOfWeek', 'groupByResources', 'headerTemplate', 'hideDateMarkers', 'hideTimelineHeader', 'hideTimelineHeaderDetails', 'hideTimelineSecondHeaderDetails', 'hideResourcePanel', 'horizontalScrollBarVisibility', 'hourFormat', 'infiniteTimeline', 'infiniteTimelineStep', 'inverted', 'keyboardNavigation', 'max', 'min', 'monthFormat', 'monthScale', 'nonworkingDays', 'nonworkingHours', 'onTaskRender', 'popupWindowCustomizationFunction', 'popupWindowTabs', 'progressLabelFormatFunction', 'quarterFormat', 'resources', 'resourceColumns', 'resourceFiltering', 'resourceGroupFormatFunction', 'resourcePanelHeaderTemplate', 'resourcePanelMin', 'resourcePanelSize', 'resourcePanelRefreshRate', 'resourceTimelineFormatFunction', 'resourceTimelineMode', 'resourceTimelineView', 'rightToLeft', 'selectedTaskIds', 'selectedResourceIds', 'shadeUntilCurrentTime', 'showSelectionColumn', 'showBaseline', 'showProgressLabel', 'snapToNearest', 'sortFunction', 'sortMode', 'tasks', 'taskColumns', 'taskFiltering', 'taskPanelMin', 'taskPanelSize', 'timelineMin', 'treeMin', 'treeSize', 'timelineHeaderFormatFunction', 'tooltip', 'verticalScrollBarVisibility', 'view', 'yearFormat', 'weekFormat', 'theme'];
        // jqxGanttComponent events
        this.onBeginUpdate = new core_1.EventEmitter();
        this.onEndUpdate = new core_1.EventEmitter();
        this.onConnectionStart = new core_1.EventEmitter();
        this.onConnectionEnd = new core_1.EventEmitter();
        this.onChange = new core_1.EventEmitter();
        this.onColumnResize = new core_1.EventEmitter();
        this.onClosing = new core_1.EventEmitter();
        this.onClose = new core_1.EventEmitter();
        this.onCollapse = new core_1.EventEmitter();
        this.onDragStart = new core_1.EventEmitter();
        this.onDragEnd = new core_1.EventEmitter();
        this.onExpand = new core_1.EventEmitter();
        this.onFilter = new core_1.EventEmitter();
        this.onItemClick = new core_1.EventEmitter();
        this.onItemInsert = new core_1.EventEmitter();
        this.onItemRemove = new core_1.EventEmitter();
        this.onItemUpdate = new core_1.EventEmitter();
        this.onOpening = new core_1.EventEmitter();
        this.onOpen = new core_1.EventEmitter();
        this.onProgressChangeStart = new core_1.EventEmitter();
        this.onProgressChangeEnd = new core_1.EventEmitter();
        this.onResizeStart = new core_1.EventEmitter();
        this.onResizeEnd = new core_1.EventEmitter();
        this.onSort = new core_1.EventEmitter();
        this.onScrollBottomReached = new core_1.EventEmitter();
        this.onScrollTopReached = new core_1.EventEmitter();
        this.onScrollLeftReached = new core_1.EventEmitter();
        this.onScrollRightReached = new core_1.EventEmitter();
        this.elementRef = containerElement;
        JQXLite(window).resize(function () {
            _this.__updateRect__();
        });
    }
    jqxGanttComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxGanttComponent.prototype.ngAfterViewInit = function () {
        window['JQX'].Render();
    };
    ;
    jqxGanttComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxGantt(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxGantt(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxGantt(this.properties[i])) {
                        this.host.jqxGantt(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxGanttComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxGanttComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxGanttComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxGanttComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxGanttComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxGantt', options);
        this.__updateRect__();
    };
    jqxGanttComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxGanttComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxGanttComponent.prototype.setOptions = function (options) {
        this.host.jqxGantt('setOptions', options);
    };
    // jqxGanttComponent properties
    jqxGanttComponent.prototype.adjustToNonworkingTime = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('adjustToNonworkingTime', arg);
        }
        else {
            return this.host.jqxGantt('adjustToNonworkingTime');
        }
    };
    jqxGanttComponent.prototype.autoSchedule = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('autoSchedule', arg);
        }
        else {
            return this.host.jqxGantt('autoSchedule');
        }
    };
    jqxGanttComponent.prototype.autoScheduleStrictMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('autoScheduleStrictMode', arg);
        }
        else {
            return this.host.jqxGantt('autoScheduleStrictMode');
        }
    };
    jqxGanttComponent.prototype.autoScrollStep = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('autoScrollStep', arg);
        }
        else {
            return this.host.jqxGantt('autoScrollStep');
        }
    };
    jqxGanttComponent.prototype.columnMenu = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('columnMenu', arg);
        }
        else {
            return this.host.jqxGantt('columnMenu');
        }
    };
    jqxGanttComponent.prototype.columnMinWidth = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('columnMinWidth', arg);
        }
        else {
            return this.host.jqxGantt('columnMinWidth');
        }
    };
    jqxGanttComponent.prototype.columnResize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('columnResize', arg);
        }
        else {
            return this.host.jqxGantt('columnResize');
        }
    };
    jqxGanttComponent.prototype.columnResizeFeedback = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('columnResizeFeedback', arg);
        }
        else {
            return this.host.jqxGantt('columnResizeFeedback');
        }
    };
    jqxGanttComponent.prototype.currentTime = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('currentTime', arg);
        }
        else {
            return this.host.jqxGantt('currentTime');
        }
    };
    jqxGanttComponent.prototype.currentTimeIndicator = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('currentTimeIndicator', arg);
        }
        else {
            return this.host.jqxGantt('currentTimeIndicator');
        }
    };
    jqxGanttComponent.prototype.currentTimeIndicatorInterval = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('currentTimeIndicatorInterval', arg);
        }
        else {
            return this.host.jqxGantt('currentTimeIndicatorInterval');
        }
    };
    jqxGanttComponent.prototype.dataExportFileName = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('dataExportFileName', arg);
        }
        else {
            return this.host.jqxGantt('dataExportFileName');
        }
    };
    jqxGanttComponent.prototype.source = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('source', arg);
        }
        else {
            return this.host.jqxGantt('source');
        }
    };
    jqxGanttComponent.prototype.dayFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('dayFormat', arg);
        }
        else {
            return this.host.jqxGantt('dayFormat');
        }
    };
    jqxGanttComponent.prototype.dateEnd = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('dateEnd', arg);
        }
        else {
            return this.host.jqxGantt('dateEnd');
        }
    };
    jqxGanttComponent.prototype.dateStart = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('dateStart', arg);
        }
        else {
            return this.host.jqxGantt('dateStart');
        }
    };
    jqxGanttComponent.prototype.dateMarkers = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('dateMarkers', arg);
        }
        else {
            return this.host.jqxGantt('dateMarkers');
        }
    };
    jqxGanttComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disabled', arg);
        }
        else {
            return this.host.jqxGantt('disabled');
        }
    };
    jqxGanttComponent.prototype.disableAutoScroll = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disableAutoScroll', arg);
        }
        else {
            return this.host.jqxGantt('disableAutoScroll');
        }
    };
    jqxGanttComponent.prototype.disableTaskDrag = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disableTaskDrag', arg);
        }
        else {
            return this.host.jqxGantt('disableTaskDrag');
        }
    };
    jqxGanttComponent.prototype.disableTaskProgressChange = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disableTaskProgressChange', arg);
        }
        else {
            return this.host.jqxGantt('disableTaskProgressChange');
        }
    };
    jqxGanttComponent.prototype.disableTaskResize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disableTaskResize', arg);
        }
        else {
            return this.host.jqxGantt('disableTaskResize');
        }
    };
    jqxGanttComponent.prototype.disableSelection = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disableSelection', arg);
        }
        else {
            return this.host.jqxGantt('disableSelection');
        }
    };
    jqxGanttComponent.prototype.disableSegmentDrag = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disableSegmentDrag', arg);
        }
        else {
            return this.host.jqxGantt('disableSegmentDrag');
        }
    };
    jqxGanttComponent.prototype.disableSegmentResize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disableSegmentResize', arg);
        }
        else {
            return this.host.jqxGantt('disableSegmentResize');
        }
    };
    jqxGanttComponent.prototype.disableWindowEditor = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('disableWindowEditor', arg);
        }
        else {
            return this.host.jqxGantt('disableWindowEditor');
        }
    };
    jqxGanttComponent.prototype.durationUnit = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('durationUnit', arg);
        }
        else {
            return this.host.jqxGantt('durationUnit');
        }
    };
    jqxGanttComponent.prototype.filterRow = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('filterRow', arg);
        }
        else {
            return this.host.jqxGantt('filterRow');
        }
    };
    jqxGanttComponent.prototype.firstDayOfWeek = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('firstDayOfWeek', arg);
        }
        else {
            return this.host.jqxGantt('firstDayOfWeek');
        }
    };
    jqxGanttComponent.prototype.groupByResources = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('groupByResources', arg);
        }
        else {
            return this.host.jqxGantt('groupByResources');
        }
    };
    jqxGanttComponent.prototype.headerTemplate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('headerTemplate', arg);
        }
        else {
            return this.host.jqxGantt('headerTemplate');
        }
    };
    jqxGanttComponent.prototype.hideDateMarkers = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('hideDateMarkers', arg);
        }
        else {
            return this.host.jqxGantt('hideDateMarkers');
        }
    };
    jqxGanttComponent.prototype.hideTimelineHeader = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('hideTimelineHeader', arg);
        }
        else {
            return this.host.jqxGantt('hideTimelineHeader');
        }
    };
    jqxGanttComponent.prototype.hideTimelineHeaderDetails = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('hideTimelineHeaderDetails', arg);
        }
        else {
            return this.host.jqxGantt('hideTimelineHeaderDetails');
        }
    };
    jqxGanttComponent.prototype.hideTimelineSecondHeaderDetails = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('hideTimelineSecondHeaderDetails', arg);
        }
        else {
            return this.host.jqxGantt('hideTimelineSecondHeaderDetails');
        }
    };
    jqxGanttComponent.prototype.hideResourcePanel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('hideResourcePanel', arg);
        }
        else {
            return this.host.jqxGantt('hideResourcePanel');
        }
    };
    jqxGanttComponent.prototype.horizontalScrollBarVisibility = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('horizontalScrollBarVisibility', arg);
        }
        else {
            return this.host.jqxGantt('horizontalScrollBarVisibility');
        }
    };
    jqxGanttComponent.prototype.hourFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('hourFormat', arg);
        }
        else {
            return this.host.jqxGantt('hourFormat');
        }
    };
    jqxGanttComponent.prototype.infiniteTimeline = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('infiniteTimeline', arg);
        }
        else {
            return this.host.jqxGantt('infiniteTimeline');
        }
    };
    jqxGanttComponent.prototype.infiniteTimelineStep = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('infiniteTimelineStep', arg);
        }
        else {
            return this.host.jqxGantt('infiniteTimelineStep');
        }
    };
    jqxGanttComponent.prototype.inverted = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('inverted', arg);
        }
        else {
            return this.host.jqxGantt('inverted');
        }
    };
    jqxGanttComponent.prototype.keyboardNavigation = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('keyboardNavigation', arg);
        }
        else {
            return this.host.jqxGantt('keyboardNavigation');
        }
    };
    jqxGanttComponent.prototype.max = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('max', arg);
        }
        else {
            return this.host.jqxGantt('max');
        }
    };
    jqxGanttComponent.prototype.min = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('min', arg);
        }
        else {
            return this.host.jqxGantt('min');
        }
    };
    jqxGanttComponent.prototype.monthFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('monthFormat', arg);
        }
        else {
            return this.host.jqxGantt('monthFormat');
        }
    };
    jqxGanttComponent.prototype.monthScale = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('monthScale', arg);
        }
        else {
            return this.host.jqxGantt('monthScale');
        }
    };
    jqxGanttComponent.prototype.nonworkingDays = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('nonworkingDays', arg);
        }
        else {
            return this.host.jqxGantt('nonworkingDays');
        }
    };
    jqxGanttComponent.prototype.nonworkingHours = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('nonworkingHours', arg);
        }
        else {
            return this.host.jqxGantt('nonworkingHours');
        }
    };
    jqxGanttComponent.prototype.onTaskRender = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('onTaskRender', arg);
        }
        else {
            return this.host.jqxGantt('onTaskRender');
        }
    };
    jqxGanttComponent.prototype.popupWindowCustomizationFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('popupWindowCustomizationFunction', arg);
        }
        else {
            return this.host.jqxGantt('popupWindowCustomizationFunction');
        }
    };
    jqxGanttComponent.prototype.popupWindowTabs = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('popupWindowTabs', arg);
        }
        else {
            return this.host.jqxGantt('popupWindowTabs');
        }
    };
    jqxGanttComponent.prototype.progressLabelFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('progressLabelFormatFunction', arg);
        }
        else {
            return this.host.jqxGantt('progressLabelFormatFunction');
        }
    };
    jqxGanttComponent.prototype.quarterFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('quarterFormat', arg);
        }
        else {
            return this.host.jqxGantt('quarterFormat');
        }
    };
    jqxGanttComponent.prototype.resources = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resources', arg);
        }
        else {
            return this.host.jqxGantt('resources');
        }
    };
    jqxGanttComponent.prototype.resourceColumns = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourceColumns', arg);
        }
        else {
            return this.host.jqxGantt('resourceColumns');
        }
    };
    jqxGanttComponent.prototype.resourceFiltering = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourceFiltering', arg);
        }
        else {
            return this.host.jqxGantt('resourceFiltering');
        }
    };
    jqxGanttComponent.prototype.resourceGroupFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourceGroupFormatFunction', arg);
        }
        else {
            return this.host.jqxGantt('resourceGroupFormatFunction');
        }
    };
    jqxGanttComponent.prototype.resourcePanelHeaderTemplate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourcePanelHeaderTemplate', arg);
        }
        else {
            return this.host.jqxGantt('resourcePanelHeaderTemplate');
        }
    };
    jqxGanttComponent.prototype.resourcePanelMin = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourcePanelMin', arg);
        }
        else {
            return this.host.jqxGantt('resourcePanelMin');
        }
    };
    jqxGanttComponent.prototype.resourcePanelSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourcePanelSize', arg);
        }
        else {
            return this.host.jqxGantt('resourcePanelSize');
        }
    };
    jqxGanttComponent.prototype.resourcePanelRefreshRate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourcePanelRefreshRate', arg);
        }
        else {
            return this.host.jqxGantt('resourcePanelRefreshRate');
        }
    };
    jqxGanttComponent.prototype.resourceTimelineFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourceTimelineFormatFunction', arg);
        }
        else {
            return this.host.jqxGantt('resourceTimelineFormatFunction');
        }
    };
    jqxGanttComponent.prototype.resourceTimelineMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourceTimelineMode', arg);
        }
        else {
            return this.host.jqxGantt('resourceTimelineMode');
        }
    };
    jqxGanttComponent.prototype.resourceTimelineView = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('resourceTimelineView', arg);
        }
        else {
            return this.host.jqxGantt('resourceTimelineView');
        }
    };
    jqxGanttComponent.prototype.rightToLeft = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('rightToLeft', arg);
        }
        else {
            return this.host.jqxGantt('rightToLeft');
        }
    };
    jqxGanttComponent.prototype.selectedTaskIds = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('selectedTaskIds', arg);
        }
        else {
            return this.host.jqxGantt('selectedTaskIds');
        }
    };
    jqxGanttComponent.prototype.selectedResourceIds = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('selectedResourceIds', arg);
        }
        else {
            return this.host.jqxGantt('selectedResourceIds');
        }
    };
    jqxGanttComponent.prototype.shadeUntilCurrentTime = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('shadeUntilCurrentTime', arg);
        }
        else {
            return this.host.jqxGantt('shadeUntilCurrentTime');
        }
    };
    jqxGanttComponent.prototype.showSelectionColumn = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('showSelectionColumn', arg);
        }
        else {
            return this.host.jqxGantt('showSelectionColumn');
        }
    };
    jqxGanttComponent.prototype.showBaseline = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('showBaseline', arg);
        }
        else {
            return this.host.jqxGantt('showBaseline');
        }
    };
    jqxGanttComponent.prototype.showProgressLabel = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('showProgressLabel', arg);
        }
        else {
            return this.host.jqxGantt('showProgressLabel');
        }
    };
    jqxGanttComponent.prototype.snapToNearest = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('snapToNearest', arg);
        }
        else {
            return this.host.jqxGantt('snapToNearest');
        }
    };
    jqxGanttComponent.prototype.sortFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('sortFunction', arg);
        }
        else {
            return this.host.jqxGantt('sortFunction');
        }
    };
    jqxGanttComponent.prototype.sortMode = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('sortMode', arg);
        }
        else {
            return this.host.jqxGantt('sortMode');
        }
    };
    jqxGanttComponent.prototype.tasks = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('tasks', arg);
        }
        else {
            return this.host.jqxGantt('tasks');
        }
    };
    jqxGanttComponent.prototype.taskColumns = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('taskColumns', arg);
        }
        else {
            return this.host.jqxGantt('taskColumns');
        }
    };
    jqxGanttComponent.prototype.taskFiltering = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('taskFiltering', arg);
        }
        else {
            return this.host.jqxGantt('taskFiltering');
        }
    };
    jqxGanttComponent.prototype.taskPanelMin = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('taskPanelMin', arg);
        }
        else {
            return this.host.jqxGantt('taskPanelMin');
        }
    };
    jqxGanttComponent.prototype.taskPanelSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('taskPanelSize', arg);
        }
        else {
            return this.host.jqxGantt('taskPanelSize');
        }
    };
    jqxGanttComponent.prototype.timelineMin = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('timelineMin', arg);
        }
        else {
            return this.host.jqxGantt('timelineMin');
        }
    };
    jqxGanttComponent.prototype.treeMin = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('treeMin', arg);
        }
        else {
            return this.host.jqxGantt('treeMin');
        }
    };
    jqxGanttComponent.prototype.treeSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('treeSize', arg);
        }
        else {
            return this.host.jqxGantt('treeSize');
        }
    };
    jqxGanttComponent.prototype.timelineHeaderFormatFunction = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('timelineHeaderFormatFunction', arg);
        }
        else {
            return this.host.jqxGantt('timelineHeaderFormatFunction');
        }
    };
    jqxGanttComponent.prototype.tooltip = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('tooltip', arg);
        }
        else {
            return this.host.jqxGantt('tooltip');
        }
    };
    jqxGanttComponent.prototype.verticalScrollBarVisibility = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('verticalScrollBarVisibility', arg);
        }
        else {
            return this.host.jqxGantt('verticalScrollBarVisibility');
        }
    };
    jqxGanttComponent.prototype.view = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('view', arg);
        }
        else {
            return this.host.jqxGantt('view');
        }
    };
    jqxGanttComponent.prototype.yearFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('yearFormat', arg);
        }
        else {
            return this.host.jqxGantt('yearFormat');
        }
    };
    jqxGanttComponent.prototype.weekFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('weekFormat', arg);
        }
        else {
            return this.host.jqxGantt('weekFormat');
        }
    };
    jqxGanttComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxGantt('theme', arg);
        }
        else {
            return this.host.jqxGantt('theme');
        }
    };
    // jqxGanttComponent functions
    jqxGanttComponent.prototype.addFilter = function (columns, filterGroup) {
        this.host.jqxGantt('addFilter', columns, filterGroup);
    };
    jqxGanttComponent.prototype.clearFilters = function () {
        this.host.jqxGantt('clearFilters');
    };
    jqxGanttComponent.prototype.clearSort = function () {
        this.host.jqxGantt('clearSort');
    };
    jqxGanttComponent.prototype.clearSelection = function () {
        this.host.jqxGantt('clearSelection');
    };
    jqxGanttComponent.prototype.clearState = function () {
        this.host.jqxGantt('clearState');
    };
    jqxGanttComponent.prototype.clearTasks = function () {
        this.host.jqxGantt('clearTasks');
    };
    jqxGanttComponent.prototype.clearResources = function () {
        this.host.jqxGantt('clearResources');
    };
    jqxGanttComponent.prototype.createConnection = function (startTaskIndex, taskEndIndex, connectionType, lag) {
        this.host.jqxGantt('createConnection', startTaskIndex, taskEndIndex, connectionType, lag);
    };
    jqxGanttComponent.prototype.collapse = function (id) {
        this.host.jqxGantt('collapse', id);
    };
    jqxGanttComponent.prototype.beginUpdate = function () {
        this.host.jqxGantt('beginUpdate');
    };
    jqxGanttComponent.prototype.endUpdate = function () {
        this.host.jqxGantt('endUpdate');
    };
    jqxGanttComponent.prototype.ensureVisible = function (taskId) {
        this.host.jqxGantt('ensureVisible', taskId);
    };
    jqxGanttComponent.prototype.expand = function (id) {
        this.host.jqxGantt('expand', id);
    };
    jqxGanttComponent.prototype.exportData = function (dataFormat, callback) {
        this.host.jqxGantt('exportData', dataFormat, callback);
    };
    jqxGanttComponent.prototype.getConnections = function () {
        return this.host.jqxGantt('getConnections');
    };
    jqxGanttComponent.prototype.getConnectionDetails = function (connectionId) {
        return this.host.jqxGantt('getConnectionDetails', connectionId);
    };
    jqxGanttComponent.prototype.getState = function () {
        return this.host.jqxGantt('getState');
    };
    jqxGanttComponent.prototype.getItemPath = function (item) {
        return this.host.jqxGantt('getItemPath', item);
    };
    jqxGanttComponent.prototype.getTask = function (itemId) {
        return this.host.jqxGantt('getTask', itemId);
    };
    jqxGanttComponent.prototype.getTasks = function () {
        return this.host.jqxGantt('getTasks');
    };
    jqxGanttComponent.prototype.getTaskIndex = function (task) {
        return this.host.jqxGantt('getTaskIndex', task);
    };
    jqxGanttComponent.prototype.getTaskConnections = function (taskId) {
        return this.host.jqxGantt('getTaskConnections', taskId);
    };
    jqxGanttComponent.prototype.getTaskProject = function (task) {
        return this.host.jqxGantt('getTaskProject', task);
    };
    jqxGanttComponent.prototype.getResource = function (itemId) {
        return this.host.jqxGantt('getResource', itemId);
    };
    jqxGanttComponent.prototype.getResources = function () {
        return this.host.jqxGantt('getResources');
    };
    jqxGanttComponent.prototype.getResourceIndex = function (resource) {
        return this.host.jqxGantt('getResourceIndex', resource);
    };
    jqxGanttComponent.prototype.getResourceTasks = function (resource) {
        return this.host.jqxGantt('getResourceTasks', resource);
    };
    jqxGanttComponent.prototype.getSelectedIds = function () {
        return this.host.jqxGantt('getSelectedIds');
    };
    jqxGanttComponent.prototype.getSelectedTasks = function () {
        return this.host.jqxGantt('getSelectedTasks');
    };
    jqxGanttComponent.prototype.getSelectedResources = function () {
        return this.host.jqxGantt('getSelectedResources');
    };
    jqxGanttComponent.prototype.getWorkingHours = function () {
        return this.host.jqxGantt('getWorkingHours');
    };
    jqxGanttComponent.prototype.hideTooltip = function () {
        return this.host.jqxGantt('hideTooltip');
    };
    jqxGanttComponent.prototype.isWorkingDay = function (date) {
        this.host.jqxGantt('isWorkingDay', date);
    };
    jqxGanttComponent.prototype.loadState = function (state) {
        this.host.jqxGantt('loadState', state);
    };
    jqxGanttComponent.prototype.removeAllConnections = function () {
        this.host.jqxGantt('removeAllConnections');
    };
    jqxGanttComponent.prototype.removeConnection = function (startTaskIndex, taskEndIndex, connectionType) {
        return this.host.jqxGantt('removeConnection', startTaskIndex, taskEndIndex, connectionType);
    };
    jqxGanttComponent.prototype.removeTaskConnection = function (taskStart, taskEnd) {
        this.host.jqxGantt('removeTaskConnection', taskStart, taskEnd);
    };
    jqxGanttComponent.prototype.showTooltip = function (target, content) {
        this.host.jqxGantt('showTooltip', target, content);
    };
    jqxGanttComponent.prototype.saveState = function (state) {
        this.host.jqxGantt('saveState', state);
    };
    jqxGanttComponent.prototype.insertTask = function (taskObject, project, index) {
        return this.host.jqxGantt('insertTask', taskObject, project, index);
    };
    jqxGanttComponent.prototype.updateTask = function (taskId, taskObject) {
        this.host.jqxGantt('updateTask', taskId, taskObject);
    };
    jqxGanttComponent.prototype.removeTask = function (taskId) {
        this.host.jqxGantt('removeTask', taskId);
    };
    jqxGanttComponent.prototype.insertResource = function (resourceId, resourceObject) {
        this.host.jqxGantt('insertResource', resourceId, resourceObject);
    };
    jqxGanttComponent.prototype.updateResource = function (resourceId, taskObject) {
        this.host.jqxGantt('updateResource', resourceId, taskObject);
    };
    jqxGanttComponent.prototype.removeResource = function (resourceId) {
        this.host.jqxGantt('removeResource', resourceId);
    };
    jqxGanttComponent.prototype.openWindow = function (taskId) {
        this.host.jqxGantt('openWindow', taskId);
    };
    jqxGanttComponent.prototype.closeWindow = function () {
        this.host.jqxGantt('closeWindow');
    };
    jqxGanttComponent.prototype.print = function () {
        this.host.jqxGantt('print');
    };
    jqxGanttComponent.prototype.setWorkTime = function (settings) {
        this.host.jqxGantt('setWorkTime', settings);
    };
    jqxGanttComponent.prototype.selectTask = function (id) {
        this.host.jqxGantt('selectTask', id);
    };
    jqxGanttComponent.prototype.selectResource = function (id) {
        this.host.jqxGantt('selectResource', id);
    };
    jqxGanttComponent.prototype.unselectTask = function (id) {
        this.host.jqxGantt('unselectTask', id);
    };
    jqxGanttComponent.prototype.unselectResource = function (id) {
        this.host.jqxGantt('unselectResource', id);
    };
    jqxGanttComponent.prototype.unsetWorkTime = function (settings) {
        this.host.jqxGantt('unsetWorkTime', settings);
    };
    jqxGanttComponent.prototype.sort = function (columns) {
        this.host.jqxGantt('sort', columns);
    };
    jqxGanttComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('beginUpdate', function (eventData) { _this.onBeginUpdate.emit(eventData); });
        this.host.on('endUpdate', function (eventData) { _this.onEndUpdate.emit(eventData); });
        this.host.on('connectionStart', function (eventData) { _this.onConnectionStart.emit(eventData); });
        this.host.on('connectionEnd', function (eventData) { _this.onConnectionEnd.emit(eventData); });
        this.host.on('change', function (eventData) { _this.onChange.emit(eventData); });
        this.host.on('columnResize', function (eventData) { _this.onColumnResize.emit(eventData); });
        this.host.on('closing', function (eventData) { _this.onClosing.emit(eventData); });
        this.host.on('close', function (eventData) { _this.onClose.emit(eventData); });
        this.host.on('collapse', function (eventData) { _this.onCollapse.emit(eventData); });
        this.host.on('dragStart', function (eventData) { _this.onDragStart.emit(eventData); });
        this.host.on('dragEnd', function (eventData) { _this.onDragEnd.emit(eventData); });
        this.host.on('expand', function (eventData) { _this.onExpand.emit(eventData); });
        this.host.on('filter', function (eventData) { _this.onFilter.emit(eventData); });
        this.host.on('itemClick', function (eventData) { _this.onItemClick.emit(eventData); });
        this.host.on('itemInsert', function (eventData) { _this.onItemInsert.emit(eventData); });
        this.host.on('itemRemove', function (eventData) { _this.onItemRemove.emit(eventData); });
        this.host.on('itemUpdate', function (eventData) { _this.onItemUpdate.emit(eventData); });
        this.host.on('opening', function (eventData) { _this.onOpening.emit(eventData); });
        this.host.on('open', function (eventData) { _this.onOpen.emit(eventData); });
        this.host.on('progressChangeStart', function (eventData) { _this.onProgressChangeStart.emit(eventData); });
        this.host.on('progressChangeEnd', function (eventData) { _this.onProgressChangeEnd.emit(eventData); });
        this.host.on('resizeStart', function (eventData) { _this.onResizeStart.emit(eventData); });
        this.host.on('resizeEnd', function (eventData) { _this.onResizeEnd.emit(eventData); });
        this.host.on('sort', function (eventData) { _this.onSort.emit(eventData); });
        this.host.on('scrollBottomReached', function (eventData) { _this.onScrollBottomReached.emit(eventData); });
        this.host.on('scrollTopReached', function (eventData) { _this.onScrollTopReached.emit(eventData); });
        this.host.on('scrollLeftReached', function (eventData) { _this.onScrollLeftReached.emit(eventData); });
        this.host.on('scrollRightReached', function (eventData) { _this.onScrollRightReached.emit(eventData); });
    };
    __decorate([
        core_1.Input('adjustToNonworkingTime')
    ], jqxGanttComponent.prototype, "attrAdjustToNonworkingTime", void 0);
    __decorate([
        core_1.Input('autoSchedule')
    ], jqxGanttComponent.prototype, "attrAutoSchedule", void 0);
    __decorate([
        core_1.Input('autoScheduleStrictMode')
    ], jqxGanttComponent.prototype, "attrAutoScheduleStrictMode", void 0);
    __decorate([
        core_1.Input('autoScrollStep')
    ], jqxGanttComponent.prototype, "attrAutoScrollStep", void 0);
    __decorate([
        core_1.Input('columnMenu')
    ], jqxGanttComponent.prototype, "attrColumnMenu", void 0);
    __decorate([
        core_1.Input('columnMinWidth')
    ], jqxGanttComponent.prototype, "attrColumnMinWidth", void 0);
    __decorate([
        core_1.Input('columnResize')
    ], jqxGanttComponent.prototype, "attrColumnResize", void 0);
    __decorate([
        core_1.Input('columnResizeFeedback')
    ], jqxGanttComponent.prototype, "attrColumnResizeFeedback", void 0);
    __decorate([
        core_1.Input('currentTime')
    ], jqxGanttComponent.prototype, "attrCurrentTime", void 0);
    __decorate([
        core_1.Input('currentTimeIndicator')
    ], jqxGanttComponent.prototype, "attrCurrentTimeIndicator", void 0);
    __decorate([
        core_1.Input('currentTimeIndicatorInterval')
    ], jqxGanttComponent.prototype, "attrCurrentTimeIndicatorInterval", void 0);
    __decorate([
        core_1.Input('dataExportFileName')
    ], jqxGanttComponent.prototype, "attrDataExportFileName", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxGanttComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('dayFormat')
    ], jqxGanttComponent.prototype, "attrDayFormat", void 0);
    __decorate([
        core_1.Input('dateEnd')
    ], jqxGanttComponent.prototype, "attrDateEnd", void 0);
    __decorate([
        core_1.Input('dateStart')
    ], jqxGanttComponent.prototype, "attrDateStart", void 0);
    __decorate([
        core_1.Input('dateMarkers')
    ], jqxGanttComponent.prototype, "attrDateMarkers", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxGanttComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('disableAutoScroll')
    ], jqxGanttComponent.prototype, "attrDisableAutoScroll", void 0);
    __decorate([
        core_1.Input('disableTaskDrag')
    ], jqxGanttComponent.prototype, "attrDisableTaskDrag", void 0);
    __decorate([
        core_1.Input('disableTaskProgressChange')
    ], jqxGanttComponent.prototype, "attrDisableTaskProgressChange", void 0);
    __decorate([
        core_1.Input('disableTaskResize')
    ], jqxGanttComponent.prototype, "attrDisableTaskResize", void 0);
    __decorate([
        core_1.Input('disableSelection')
    ], jqxGanttComponent.prototype, "attrDisableSelection", void 0);
    __decorate([
        core_1.Input('disableSegmentDrag')
    ], jqxGanttComponent.prototype, "attrDisableSegmentDrag", void 0);
    __decorate([
        core_1.Input('disableSegmentResize')
    ], jqxGanttComponent.prototype, "attrDisableSegmentResize", void 0);
    __decorate([
        core_1.Input('disableWindowEditor')
    ], jqxGanttComponent.prototype, "attrDisableWindowEditor", void 0);
    __decorate([
        core_1.Input('durationUnit')
    ], jqxGanttComponent.prototype, "attrDurationUnit", void 0);
    __decorate([
        core_1.Input('filterRow')
    ], jqxGanttComponent.prototype, "attrFilterRow", void 0);
    __decorate([
        core_1.Input('firstDayOfWeek')
    ], jqxGanttComponent.prototype, "attrFirstDayOfWeek", void 0);
    __decorate([
        core_1.Input('groupByResources')
    ], jqxGanttComponent.prototype, "attrGroupByResources", void 0);
    __decorate([
        core_1.Input('headerTemplate')
    ], jqxGanttComponent.prototype, "attrHeaderTemplate", void 0);
    __decorate([
        core_1.Input('hideDateMarkers')
    ], jqxGanttComponent.prototype, "attrHideDateMarkers", void 0);
    __decorate([
        core_1.Input('hideTimelineHeader')
    ], jqxGanttComponent.prototype, "attrHideTimelineHeader", void 0);
    __decorate([
        core_1.Input('hideTimelineHeaderDetails')
    ], jqxGanttComponent.prototype, "attrHideTimelineHeaderDetails", void 0);
    __decorate([
        core_1.Input('hideTimelineSecondHeaderDetails')
    ], jqxGanttComponent.prototype, "attrHideTimelineSecondHeaderDetails", void 0);
    __decorate([
        core_1.Input('hideResourcePanel')
    ], jqxGanttComponent.prototype, "attrHideResourcePanel", void 0);
    __decorate([
        core_1.Input('horizontalScrollBarVisibility')
    ], jqxGanttComponent.prototype, "attrHorizontalScrollBarVisibility", void 0);
    __decorate([
        core_1.Input('hourFormat')
    ], jqxGanttComponent.prototype, "attrHourFormat", void 0);
    __decorate([
        core_1.Input('infiniteTimeline')
    ], jqxGanttComponent.prototype, "attrInfiniteTimeline", void 0);
    __decorate([
        core_1.Input('infiniteTimelineStep')
    ], jqxGanttComponent.prototype, "attrInfiniteTimelineStep", void 0);
    __decorate([
        core_1.Input('inverted')
    ], jqxGanttComponent.prototype, "attrInverted", void 0);
    __decorate([
        core_1.Input('keyboardNavigation')
    ], jqxGanttComponent.prototype, "attrKeyboardNavigation", void 0);
    __decorate([
        core_1.Input('max')
    ], jqxGanttComponent.prototype, "attrMax", void 0);
    __decorate([
        core_1.Input('min')
    ], jqxGanttComponent.prototype, "attrMin", void 0);
    __decorate([
        core_1.Input('monthFormat')
    ], jqxGanttComponent.prototype, "attrMonthFormat", void 0);
    __decorate([
        core_1.Input('monthScale')
    ], jqxGanttComponent.prototype, "attrMonthScale", void 0);
    __decorate([
        core_1.Input('nonworkingDays')
    ], jqxGanttComponent.prototype, "attrNonworkingDays", void 0);
    __decorate([
        core_1.Input('nonworkingHours')
    ], jqxGanttComponent.prototype, "attrNonworkingHours", void 0);
    __decorate([
        core_1.Input('onTaskRender')
    ], jqxGanttComponent.prototype, "attrOnTaskRender", void 0);
    __decorate([
        core_1.Input('popupWindowCustomizationFunction')
    ], jqxGanttComponent.prototype, "attrPopupWindowCustomizationFunction", void 0);
    __decorate([
        core_1.Input('popupWindowTabs')
    ], jqxGanttComponent.prototype, "attrPopupWindowTabs", void 0);
    __decorate([
        core_1.Input('progressLabelFormatFunction')
    ], jqxGanttComponent.prototype, "attrProgressLabelFormatFunction", void 0);
    __decorate([
        core_1.Input('quarterFormat')
    ], jqxGanttComponent.prototype, "attrQuarterFormat", void 0);
    __decorate([
        core_1.Input('resources')
    ], jqxGanttComponent.prototype, "attrResources", void 0);
    __decorate([
        core_1.Input('resourceColumns')
    ], jqxGanttComponent.prototype, "attrResourceColumns", void 0);
    __decorate([
        core_1.Input('resourceFiltering')
    ], jqxGanttComponent.prototype, "attrResourceFiltering", void 0);
    __decorate([
        core_1.Input('resourceGroupFormatFunction')
    ], jqxGanttComponent.prototype, "attrResourceGroupFormatFunction", void 0);
    __decorate([
        core_1.Input('resourcePanelHeaderTemplate')
    ], jqxGanttComponent.prototype, "attrResourcePanelHeaderTemplate", void 0);
    __decorate([
        core_1.Input('resourcePanelMin')
    ], jqxGanttComponent.prototype, "attrResourcePanelMin", void 0);
    __decorate([
        core_1.Input('resourcePanelSize')
    ], jqxGanttComponent.prototype, "attrResourcePanelSize", void 0);
    __decorate([
        core_1.Input('resourcePanelRefreshRate')
    ], jqxGanttComponent.prototype, "attrResourcePanelRefreshRate", void 0);
    __decorate([
        core_1.Input('resourceTimelineFormatFunction')
    ], jqxGanttComponent.prototype, "attrResourceTimelineFormatFunction", void 0);
    __decorate([
        core_1.Input('resourceTimelineMode')
    ], jqxGanttComponent.prototype, "attrResourceTimelineMode", void 0);
    __decorate([
        core_1.Input('resourceTimelineView')
    ], jqxGanttComponent.prototype, "attrResourceTimelineView", void 0);
    __decorate([
        core_1.Input('rightToLeft')
    ], jqxGanttComponent.prototype, "attrRightToLeft", void 0);
    __decorate([
        core_1.Input('selectedTaskIds')
    ], jqxGanttComponent.prototype, "attrSelectedTaskIds", void 0);
    __decorate([
        core_1.Input('selectedResourceIds')
    ], jqxGanttComponent.prototype, "attrSelectedResourceIds", void 0);
    __decorate([
        core_1.Input('shadeUntilCurrentTime')
    ], jqxGanttComponent.prototype, "attrShadeUntilCurrentTime", void 0);
    __decorate([
        core_1.Input('showSelectionColumn')
    ], jqxGanttComponent.prototype, "attrShowSelectionColumn", void 0);
    __decorate([
        core_1.Input('showBaseline')
    ], jqxGanttComponent.prototype, "attrShowBaseline", void 0);
    __decorate([
        core_1.Input('showProgressLabel')
    ], jqxGanttComponent.prototype, "attrShowProgressLabel", void 0);
    __decorate([
        core_1.Input('snapToNearest')
    ], jqxGanttComponent.prototype, "attrSnapToNearest", void 0);
    __decorate([
        core_1.Input('sortFunction')
    ], jqxGanttComponent.prototype, "attrSortFunction", void 0);
    __decorate([
        core_1.Input('sortMode')
    ], jqxGanttComponent.prototype, "attrSortMode", void 0);
    __decorate([
        core_1.Input('tasks')
    ], jqxGanttComponent.prototype, "attrTasks", void 0);
    __decorate([
        core_1.Input('taskColumns')
    ], jqxGanttComponent.prototype, "attrTaskColumns", void 0);
    __decorate([
        core_1.Input('taskFiltering')
    ], jqxGanttComponent.prototype, "attrTaskFiltering", void 0);
    __decorate([
        core_1.Input('taskPanelMin')
    ], jqxGanttComponent.prototype, "attrTaskPanelMin", void 0);
    __decorate([
        core_1.Input('taskPanelSize')
    ], jqxGanttComponent.prototype, "attrTaskPanelSize", void 0);
    __decorate([
        core_1.Input('timelineMin')
    ], jqxGanttComponent.prototype, "attrTimelineMin", void 0);
    __decorate([
        core_1.Input('treeMin')
    ], jqxGanttComponent.prototype, "attrTreeMin", void 0);
    __decorate([
        core_1.Input('treeSize')
    ], jqxGanttComponent.prototype, "attrTreeSize", void 0);
    __decorate([
        core_1.Input('timelineHeaderFormatFunction')
    ], jqxGanttComponent.prototype, "attrTimelineHeaderFormatFunction", void 0);
    __decorate([
        core_1.Input('tooltip')
    ], jqxGanttComponent.prototype, "attrTooltip", void 0);
    __decorate([
        core_1.Input('verticalScrollBarVisibility')
    ], jqxGanttComponent.prototype, "attrVerticalScrollBarVisibility", void 0);
    __decorate([
        core_1.Input('view')
    ], jqxGanttComponent.prototype, "attrView", void 0);
    __decorate([
        core_1.Input('yearFormat')
    ], jqxGanttComponent.prototype, "attrYearFormat", void 0);
    __decorate([
        core_1.Input('weekFormat')
    ], jqxGanttComponent.prototype, "attrWeekFormat", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxGanttComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxGanttComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxGanttComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxGanttComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onBeginUpdate", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onEndUpdate", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onConnectionStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onConnectionEnd", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onColumnResize", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onClosing", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onCollapse", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onDragStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onDragEnd", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onExpand", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onFilter", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onItemClick", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onItemInsert", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onItemRemove", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onItemUpdate", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onOpening", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onProgressChangeStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onProgressChangeEnd", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onResizeStart", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onResizeEnd", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onSort", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onScrollBottomReached", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onScrollTopReached", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onScrollLeftReached", void 0);
    __decorate([
        core_1.Output()
    ], jqxGanttComponent.prototype, "onScrollRightReached", void 0);
    jqxGanttComponent = __decorate([
        core_1.Component({
            selector: 'jqxGantt',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxGanttComponent);
    return jqxGanttComponent;
}()); //jqxGanttComponent
exports.jqxGanttComponent = jqxGanttComponent;
