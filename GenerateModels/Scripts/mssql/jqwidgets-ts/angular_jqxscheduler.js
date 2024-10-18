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
require("../jqwidgets/modules/jqxscheduler.js");
var core_1 = require("@angular/core");
var jqxSchedulerComponent = /** @class */ (function () {
    function jqxSchedulerComponent(containerElement) {
        this.autoCreate = true;
        this.properties = ['appointmentOpacity', 'appointmentsMinHeight', 'appointmentDataFields', 'appointmentTooltips', 'columnsHeight', 'contextMenu', 'contextMenuOpen', 'contextMenuClose', 'contextMenuItemClick', 'contextMenuCreate', 'changedAppointments', 'disabled', 'date', 'dayNameFormat', 'enableHover', 'editDialog', 'editDialogDateTimeFormatString', 'editDialogDateFormatString', 'editDialogOpen', 'editDialogCreate', 'editDialogKeyDown', 'editDialogClose', 'exportSettings', 'height', 'legendPosition', 'legendHeight', 'localization', 'min', 'max', 'ready', 'renderAppointment', 'rendering', 'rendered', 'rtl', 'resources', 'rowsHeight', 'showToolbar', 'showLegend', 'showCurrent', 'showCurrentAppointment', 'scrollBarSize', 'source', 'statuses', 'touchRowsHeight', 'theme', 'touchAppointmentsMinHeight', 'touchScrollBarSize', 'timeZone', 'touchDayNameFormat', 'toolBarRangeFormat', 'toolBarRangeFormatAbbr', 'toolbarHeight', 'views', 'view', 'width'];
        // jqxSchedulerComponent events
        this.onAppointmentChange = new core_1.EventEmitter();
        this.onAppointmentClick = new core_1.EventEmitter();
        this.onAppointmentDoubleClick = new core_1.EventEmitter();
        this.onAppointmentDelete = new core_1.EventEmitter();
        this.onAppointmentAdd = new core_1.EventEmitter();
        this.onBindingComplete = new core_1.EventEmitter();
        this.onCellClick = new core_1.EventEmitter();
        this.onCellDoubleClick = new core_1.EventEmitter();
        this.onContextMenuOpen = new core_1.EventEmitter();
        this.onContextMenuClose = new core_1.EventEmitter();
        this.onContextMenuItemClick = new core_1.EventEmitter();
        this.onContextMenuCreate = new core_1.EventEmitter();
        this.onDateChange = new core_1.EventEmitter();
        this.onEditRecurrenceDialogOpen = new core_1.EventEmitter();
        this.onEditRecurrenceDialogClose = new core_1.EventEmitter();
        this.onEditDialogCreate = new core_1.EventEmitter();
        this.onEditDialogOpen = new core_1.EventEmitter();
        this.onEditDialogClose = new core_1.EventEmitter();
        this.onViewChange = new core_1.EventEmitter();
        this.elementRef = containerElement;
    }
    jqxSchedulerComponent.prototype.ngOnInit = function () {
        if (this.autoCreate) {
            this.createComponent();
        }
    };
    ;
    jqxSchedulerComponent.prototype.ngOnChanges = function (changes) {
        if (this.host) {
            for (var i = 0; i < this.properties.length; i++) {
                var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
                var areEqual = false;
                if (this[attrName] !== undefined) {
                    if (typeof this[attrName] === 'object') {
                        if (this[attrName] instanceof Array) {
                            areEqual = this.arraysEqual(this[attrName], this.host.jqxScheduler(this.properties[i]));
                        }
                        if (areEqual) {
                            return false;
                        }
                        this.host.jqxScheduler(this.properties[i], this[attrName]);
                        continue;
                    }
                    if (this[attrName] !== this.host.jqxScheduler(this.properties[i])) {
                        this.host.jqxScheduler(this.properties[i], this[attrName]);
                    }
                }
            }
        }
    };
    jqxSchedulerComponent.prototype.arraysEqual = function (attrValue, hostValue) {
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
    jqxSchedulerComponent.prototype.manageAttributes = function () {
        var options = {};
        for (var i = 0; i < this.properties.length; i++) {
            var attrName = 'attr' + this.properties[i].substring(0, 1).toUpperCase() + this.properties[i].substring(1);
            if (this[attrName] !== undefined) {
                options[this.properties[i]] = this[attrName];
            }
        }
        return options;
    };
    jqxSchedulerComponent.prototype.moveClasses = function (parentEl, childEl) {
        var _a;
        var classes = parentEl.classList;
        if (classes.length > 0) {
            (_a = childEl.classList).add.apply(_a, classes);
        }
        parentEl.className = '';
    };
    jqxSchedulerComponent.prototype.moveStyles = function (parentEl, childEl) {
        var style = parentEl.style.cssText;
        childEl.style.cssText = style;
        parentEl.style.cssText = '';
    };
    jqxSchedulerComponent.prototype.createComponent = function (options) {
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
        this.widgetObject = jqwidgets.createInstance(this.host, 'jqxScheduler', options);
    };
    jqxSchedulerComponent.prototype.createWidget = function (options) {
        this.createComponent(options);
    };
    jqxSchedulerComponent.prototype.__updateRect__ = function () {
        if (this.host)
            this.host.css({ width: this.attrWidth, height: this.attrHeight });
    };
    jqxSchedulerComponent.prototype.setOptions = function (options) {
        this.host.jqxScheduler('setOptions', options);
    };
    // jqxSchedulerComponent properties
    jqxSchedulerComponent.prototype.appointmentOpacity = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('appointmentOpacity', arg);
        }
        else {
            return this.host.jqxScheduler('appointmentOpacity');
        }
    };
    jqxSchedulerComponent.prototype.appointmentsMinHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('appointmentsMinHeight', arg);
        }
        else {
            return this.host.jqxScheduler('appointmentsMinHeight');
        }
    };
    jqxSchedulerComponent.prototype.appointmentDataFields = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('appointmentDataFields', arg);
        }
        else {
            return this.host.jqxScheduler('appointmentDataFields');
        }
    };
    jqxSchedulerComponent.prototype.appointmentTooltips = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('appointmentTooltips', arg);
        }
        else {
            return this.host.jqxScheduler('appointmentTooltips');
        }
    };
    jqxSchedulerComponent.prototype.columnsHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('columnsHeight', arg);
        }
        else {
            return this.host.jqxScheduler('columnsHeight');
        }
    };
    jqxSchedulerComponent.prototype.contextMenu = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('contextMenu', arg);
        }
        else {
            return this.host.jqxScheduler('contextMenu');
        }
    };
    jqxSchedulerComponent.prototype.contextMenuOpen = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('contextMenuOpen', arg);
        }
        else {
            return this.host.jqxScheduler('contextMenuOpen');
        }
    };
    jqxSchedulerComponent.prototype.contextMenuClose = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('contextMenuClose', arg);
        }
        else {
            return this.host.jqxScheduler('contextMenuClose');
        }
    };
    jqxSchedulerComponent.prototype.contextMenuItemClick = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('contextMenuItemClick', arg);
        }
        else {
            return this.host.jqxScheduler('contextMenuItemClick');
        }
    };
    jqxSchedulerComponent.prototype.contextMenuCreate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('contextMenuCreate', arg);
        }
        else {
            return this.host.jqxScheduler('contextMenuCreate');
        }
    };
    jqxSchedulerComponent.prototype.changedAppointments = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('changedAppointments', arg);
        }
        else {
            return this.host.jqxScheduler('changedAppointments');
        }
    };
    jqxSchedulerComponent.prototype.disabled = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('disabled', arg);
        }
        else {
            return this.host.jqxScheduler('disabled');
        }
    };
    jqxSchedulerComponent.prototype.date = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('date', arg);
        }
        else {
            return this.host.jqxScheduler('date');
        }
    };
    jqxSchedulerComponent.prototype.dayNameFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('dayNameFormat', arg);
        }
        else {
            return this.host.jqxScheduler('dayNameFormat');
        }
    };
    jqxSchedulerComponent.prototype.enableHover = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('enableHover', arg);
        }
        else {
            return this.host.jqxScheduler('enableHover');
        }
    };
    jqxSchedulerComponent.prototype.editDialog = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('editDialog', arg);
        }
        else {
            return this.host.jqxScheduler('editDialog');
        }
    };
    jqxSchedulerComponent.prototype.editDialogDateTimeFormatString = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('editDialogDateTimeFormatString', arg);
        }
        else {
            return this.host.jqxScheduler('editDialogDateTimeFormatString');
        }
    };
    jqxSchedulerComponent.prototype.editDialogDateFormatString = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('editDialogDateFormatString', arg);
        }
        else {
            return this.host.jqxScheduler('editDialogDateFormatString');
        }
    };
    jqxSchedulerComponent.prototype.editDialogOpen = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('editDialogOpen', arg);
        }
        else {
            return this.host.jqxScheduler('editDialogOpen');
        }
    };
    jqxSchedulerComponent.prototype.editDialogCreate = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('editDialogCreate', arg);
        }
        else {
            return this.host.jqxScheduler('editDialogCreate');
        }
    };
    jqxSchedulerComponent.prototype.editDialogKeyDown = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('editDialogKeyDown', arg);
        }
        else {
            return this.host.jqxScheduler('editDialogKeyDown');
        }
    };
    jqxSchedulerComponent.prototype.editDialogClose = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('editDialogClose', arg);
        }
        else {
            return this.host.jqxScheduler('editDialogClose');
        }
    };
    jqxSchedulerComponent.prototype.exportSettings = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('exportSettings', arg);
        }
        else {
            return this.host.jqxScheduler('exportSettings');
        }
    };
    jqxSchedulerComponent.prototype.height = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('height', arg);
        }
        else {
            return this.host.jqxScheduler('height');
        }
    };
    jqxSchedulerComponent.prototype.legendPosition = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('legendPosition', arg);
        }
        else {
            return this.host.jqxScheduler('legendPosition');
        }
    };
    jqxSchedulerComponent.prototype.legendHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('legendHeight', arg);
        }
        else {
            return this.host.jqxScheduler('legendHeight');
        }
    };
    jqxSchedulerComponent.prototype.localization = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('localization', arg);
        }
        else {
            return this.host.jqxScheduler('localization');
        }
    };
    jqxSchedulerComponent.prototype.min = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('min', arg);
        }
        else {
            return this.host.jqxScheduler('min');
        }
    };
    jqxSchedulerComponent.prototype.max = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('max', arg);
        }
        else {
            return this.host.jqxScheduler('max');
        }
    };
    jqxSchedulerComponent.prototype.ready = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('ready', arg);
        }
        else {
            return this.host.jqxScheduler('ready');
        }
    };
    jqxSchedulerComponent.prototype.renderAppointment = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('renderAppointment', arg);
        }
        else {
            return this.host.jqxScheduler('renderAppointment');
        }
    };
    jqxSchedulerComponent.prototype.rendering = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('rendering', arg);
        }
        else {
            return this.host.jqxScheduler('rendering');
        }
    };
    jqxSchedulerComponent.prototype.rendered = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('rendered', arg);
        }
        else {
            return this.host.jqxScheduler('rendered');
        }
    };
    jqxSchedulerComponent.prototype.rtl = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('rtl', arg);
        }
        else {
            return this.host.jqxScheduler('rtl');
        }
    };
    jqxSchedulerComponent.prototype.resources = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('resources', arg);
        }
        else {
            return this.host.jqxScheduler('resources');
        }
    };
    jqxSchedulerComponent.prototype.rowsHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('rowsHeight', arg);
        }
        else {
            return this.host.jqxScheduler('rowsHeight');
        }
    };
    jqxSchedulerComponent.prototype.showToolbar = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('showToolbar', arg);
        }
        else {
            return this.host.jqxScheduler('showToolbar');
        }
    };
    jqxSchedulerComponent.prototype.showLegend = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('showLegend', arg);
        }
        else {
            return this.host.jqxScheduler('showLegend');
        }
    };
    jqxSchedulerComponent.prototype.showCurrent = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('showCurrent', arg);
        }
        else {
            return this.host.jqxScheduler('showCurrent');
        }
    };
    jqxSchedulerComponent.prototype.showCurrentAppointment = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('showCurrentAppointment', arg);
        }
        else {
            return this.host.jqxScheduler('showCurrentAppointment');
        }
    };
    jqxSchedulerComponent.prototype.scrollBarSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('scrollBarSize', arg);
        }
        else {
            return this.host.jqxScheduler('scrollBarSize');
        }
    };
    jqxSchedulerComponent.prototype.source = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('source', arg);
        }
        else {
            return this.host.jqxScheduler('source');
        }
    };
    jqxSchedulerComponent.prototype.statuses = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('statuses', arg);
        }
        else {
            return this.host.jqxScheduler('statuses');
        }
    };
    jqxSchedulerComponent.prototype.touchRowsHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('touchRowsHeight', arg);
        }
        else {
            return this.host.jqxScheduler('touchRowsHeight');
        }
    };
    jqxSchedulerComponent.prototype.theme = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('theme', arg);
        }
        else {
            return this.host.jqxScheduler('theme');
        }
    };
    jqxSchedulerComponent.prototype.touchAppointmentsMinHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('touchAppointmentsMinHeight', arg);
        }
        else {
            return this.host.jqxScheduler('touchAppointmentsMinHeight');
        }
    };
    jqxSchedulerComponent.prototype.touchScrollBarSize = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('touchScrollBarSize', arg);
        }
        else {
            return this.host.jqxScheduler('touchScrollBarSize');
        }
    };
    jqxSchedulerComponent.prototype.timeZone = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('timeZone', arg);
        }
        else {
            return this.host.jqxScheduler('timeZone');
        }
    };
    jqxSchedulerComponent.prototype.touchDayNameFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('touchDayNameFormat', arg);
        }
        else {
            return this.host.jqxScheduler('touchDayNameFormat');
        }
    };
    jqxSchedulerComponent.prototype.toolBarRangeFormat = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('toolBarRangeFormat', arg);
        }
        else {
            return this.host.jqxScheduler('toolBarRangeFormat');
        }
    };
    jqxSchedulerComponent.prototype.toolBarRangeFormatAbbr = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('toolBarRangeFormatAbbr', arg);
        }
        else {
            return this.host.jqxScheduler('toolBarRangeFormatAbbr');
        }
    };
    jqxSchedulerComponent.prototype.toolbarHeight = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('toolbarHeight', arg);
        }
        else {
            return this.host.jqxScheduler('toolbarHeight');
        }
    };
    jqxSchedulerComponent.prototype.views = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('views', arg);
        }
        else {
            return this.host.jqxScheduler('views');
        }
    };
    jqxSchedulerComponent.prototype.view = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('view', arg);
        }
        else {
            return this.host.jqxScheduler('view');
        }
    };
    jqxSchedulerComponent.prototype.width = function (arg) {
        if (arg !== undefined) {
            this.host.jqxScheduler('width', arg);
        }
        else {
            return this.host.jqxScheduler('width');
        }
    };
    // jqxSchedulerComponent functions
    jqxSchedulerComponent.prototype.addAppointment = function (item) {
        this.host.jqxScheduler('addAppointment', item);
    };
    jqxSchedulerComponent.prototype.beginAppointmentsUpdate = function () {
        this.host.jqxScheduler('beginAppointmentsUpdate');
    };
    jqxSchedulerComponent.prototype.clearAppointmentsSelection = function () {
        this.host.jqxScheduler('clearAppointmentsSelection');
    };
    jqxSchedulerComponent.prototype.clearSelection = function () {
        this.host.jqxScheduler('clearSelection');
    };
    jqxSchedulerComponent.prototype.closeMenu = function () {
        this.host.jqxScheduler('closeMenu');
    };
    jqxSchedulerComponent.prototype.closeDialog = function () {
        this.host.jqxScheduler('closeDialog');
    };
    jqxSchedulerComponent.prototype.deleteAppointment = function (appointmenId) {
        this.host.jqxScheduler('deleteAppointment', appointmenId);
    };
    jqxSchedulerComponent.prototype.destroy = function () {
        this.host.jqxScheduler('destroy');
    };
    jqxSchedulerComponent.prototype.endAppointmentsUpdate = function () {
        this.host.jqxScheduler('endAppointmentsUpdate');
    };
    jqxSchedulerComponent.prototype.ensureAppointmentVisible = function (id) {
        this.host.jqxScheduler('ensureAppointmentVisible', id);
    };
    jqxSchedulerComponent.prototype.ensureVisible = function (item, resourceId) {
        this.host.jqxScheduler('ensureVisible', item, resourceId);
    };
    jqxSchedulerComponent.prototype.exportData = function (format) {
        return this.host.jqxScheduler('exportData', format);
    };
    jqxSchedulerComponent.prototype.focus = function () {
        this.host.jqxScheduler('focus');
    };
    jqxSchedulerComponent.prototype.getAppointmentProperty = function (appointmentId, name) {
        return this.host.jqxScheduler('getAppointmentProperty', appointmentId, name);
    };
    jqxSchedulerComponent.prototype.getSelection = function () {
        return this.host.jqxScheduler('getSelection');
    };
    jqxSchedulerComponent.prototype.getAppointments = function () {
        return this.host.jqxScheduler('getAppointments');
    };
    jqxSchedulerComponent.prototype.getDataAppointments = function () {
        return this.host.jqxScheduler('getDataAppointments');
    };
    jqxSchedulerComponent.prototype.hideAppointmentsByResource = function (resourcesId) {
        this.host.jqxScheduler('hideAppointmentsByResource', resourcesId);
    };
    jqxSchedulerComponent.prototype.openMenu = function (left, top) {
        this.host.jqxScheduler('openMenu', left, top);
    };
    jqxSchedulerComponent.prototype.openDialog = function (left, top) {
        this.host.jqxScheduler('openDialog', left, top);
    };
    jqxSchedulerComponent.prototype.selectAppointment = function (appointmentId) {
        this.host.jqxScheduler('selectAppointment', appointmentId);
    };
    jqxSchedulerComponent.prototype.setAppointmentProperty = function (appointmentId, name, value) {
        this.host.jqxScheduler('setAppointmentProperty', appointmentId, name, value);
    };
    jqxSchedulerComponent.prototype.selectCell = function (date, allday, resourceId) {
        this.host.jqxScheduler('selectCell', date, allday, resourceId);
    };
    jqxSchedulerComponent.prototype.showAppointmentsByResource = function (resourceId) {
        this.host.jqxScheduler('showAppointmentsByResource', resourceId);
    };
    jqxSchedulerComponent.prototype.scrollWidth = function () {
        return this.host.jqxScheduler('scrollWidth');
    };
    jqxSchedulerComponent.prototype.scrollHeight = function () {
        return this.host.jqxScheduler('scrollHeight');
    };
    jqxSchedulerComponent.prototype.scrollLeft = function (left) {
        this.host.jqxScheduler('scrollLeft', left);
    };
    jqxSchedulerComponent.prototype.scrollTop = function (top) {
        this.host.jqxScheduler('scrollTop', top);
    };
    jqxSchedulerComponent.prototype.__wireEvents__ = function () {
        var _this = this;
        this.host.on('appointmentChange', function (eventData) { _this.onAppointmentChange.emit(eventData); });
        this.host.on('appointmentClick', function (eventData) { _this.onAppointmentClick.emit(eventData); });
        this.host.on('appointmentDoubleClick', function (eventData) { _this.onAppointmentDoubleClick.emit(eventData); });
        this.host.on('appointmentDelete', function (eventData) { _this.onAppointmentDelete.emit(eventData); });
        this.host.on('appointmentAdd', function (eventData) { _this.onAppointmentAdd.emit(eventData); });
        this.host.on('bindingComplete', function (eventData) { _this.onBindingComplete.emit(eventData); });
        this.host.on('cellClick', function (eventData) { _this.onCellClick.emit(eventData); });
        this.host.on('cellDoubleClick', function (eventData) { _this.onCellDoubleClick.emit(eventData); });
        this.host.on('contextMenuOpen', function (eventData) { _this.onContextMenuOpen.emit(eventData); });
        this.host.on('contextMenuClose', function (eventData) { _this.onContextMenuClose.emit(eventData); });
        this.host.on('contextMenuItemClick', function (eventData) { _this.onContextMenuItemClick.emit(eventData); });
        this.host.on('contextMenuCreate', function (eventData) { _this.onContextMenuCreate.emit(eventData); });
        this.host.on('dateChange', function (eventData) { _this.onDateChange.emit(eventData); });
        this.host.on('editRecurrenceDialogOpen', function (eventData) { _this.onEditRecurrenceDialogOpen.emit(eventData); });
        this.host.on('editRecurrenceDialogClose', function (eventData) { _this.onEditRecurrenceDialogClose.emit(eventData); });
        this.host.on('editDialogCreate', function (eventData) { _this.onEditDialogCreate.emit(eventData); });
        this.host.on('editDialogOpen', function (eventData) { _this.onEditDialogOpen.emit(eventData); });
        this.host.on('editDialogClose', function (eventData) { _this.onEditDialogClose.emit(eventData); });
        this.host.on('viewChange', function (eventData) { _this.onViewChange.emit(eventData); });
    };
    __decorate([
        core_1.Input('appointmentOpacity')
    ], jqxSchedulerComponent.prototype, "attrAppointmentOpacity", void 0);
    __decorate([
        core_1.Input('appointmentsMinHeight')
    ], jqxSchedulerComponent.prototype, "attrAppointmentsMinHeight", void 0);
    __decorate([
        core_1.Input('appointmentDataFields')
    ], jqxSchedulerComponent.prototype, "attrAppointmentDataFields", void 0);
    __decorate([
        core_1.Input('appointmentTooltips')
    ], jqxSchedulerComponent.prototype, "attrAppointmentTooltips", void 0);
    __decorate([
        core_1.Input('columnsHeight')
    ], jqxSchedulerComponent.prototype, "attrColumnsHeight", void 0);
    __decorate([
        core_1.Input('contextMenu')
    ], jqxSchedulerComponent.prototype, "attrContextMenu", void 0);
    __decorate([
        core_1.Input('contextMenuOpen')
    ], jqxSchedulerComponent.prototype, "attrContextMenuOpen", void 0);
    __decorate([
        core_1.Input('contextMenuClose')
    ], jqxSchedulerComponent.prototype, "attrContextMenuClose", void 0);
    __decorate([
        core_1.Input('contextMenuItemClick')
    ], jqxSchedulerComponent.prototype, "attrContextMenuItemClick", void 0);
    __decorate([
        core_1.Input('contextMenuCreate')
    ], jqxSchedulerComponent.prototype, "attrContextMenuCreate", void 0);
    __decorate([
        core_1.Input('changedAppointments')
    ], jqxSchedulerComponent.prototype, "attrChangedAppointments", void 0);
    __decorate([
        core_1.Input('disabled')
    ], jqxSchedulerComponent.prototype, "attrDisabled", void 0);
    __decorate([
        core_1.Input('date')
    ], jqxSchedulerComponent.prototype, "attrDate", void 0);
    __decorate([
        core_1.Input('dayNameFormat')
    ], jqxSchedulerComponent.prototype, "attrDayNameFormat", void 0);
    __decorate([
        core_1.Input('enableHover')
    ], jqxSchedulerComponent.prototype, "attrEnableHover", void 0);
    __decorate([
        core_1.Input('editDialog')
    ], jqxSchedulerComponent.prototype, "attrEditDialog", void 0);
    __decorate([
        core_1.Input('editDialogDateTimeFormatString')
    ], jqxSchedulerComponent.prototype, "attrEditDialogDateTimeFormatString", void 0);
    __decorate([
        core_1.Input('editDialogDateFormatString')
    ], jqxSchedulerComponent.prototype, "attrEditDialogDateFormatString", void 0);
    __decorate([
        core_1.Input('editDialogOpen')
    ], jqxSchedulerComponent.prototype, "attrEditDialogOpen", void 0);
    __decorate([
        core_1.Input('editDialogCreate')
    ], jqxSchedulerComponent.prototype, "attrEditDialogCreate", void 0);
    __decorate([
        core_1.Input('editDialogKeyDown')
    ], jqxSchedulerComponent.prototype, "attrEditDialogKeyDown", void 0);
    __decorate([
        core_1.Input('editDialogClose')
    ], jqxSchedulerComponent.prototype, "attrEditDialogClose", void 0);
    __decorate([
        core_1.Input('exportSettings')
    ], jqxSchedulerComponent.prototype, "attrExportSettings", void 0);
    __decorate([
        core_1.Input('legendPosition')
    ], jqxSchedulerComponent.prototype, "attrLegendPosition", void 0);
    __decorate([
        core_1.Input('legendHeight')
    ], jqxSchedulerComponent.prototype, "attrLegendHeight", void 0);
    __decorate([
        core_1.Input('localization')
    ], jqxSchedulerComponent.prototype, "attrLocalization", void 0);
    __decorate([
        core_1.Input('min')
    ], jqxSchedulerComponent.prototype, "attrMin", void 0);
    __decorate([
        core_1.Input('max')
    ], jqxSchedulerComponent.prototype, "attrMax", void 0);
    __decorate([
        core_1.Input('ready')
    ], jqxSchedulerComponent.prototype, "attrReady", void 0);
    __decorate([
        core_1.Input('renderAppointment')
    ], jqxSchedulerComponent.prototype, "attrRenderAppointment", void 0);
    __decorate([
        core_1.Input('rendering')
    ], jqxSchedulerComponent.prototype, "attrRendering", void 0);
    __decorate([
        core_1.Input('rendered')
    ], jqxSchedulerComponent.prototype, "attrRendered", void 0);
    __decorate([
        core_1.Input('rtl')
    ], jqxSchedulerComponent.prototype, "attrRtl", void 0);
    __decorate([
        core_1.Input('resources')
    ], jqxSchedulerComponent.prototype, "attrResources", void 0);
    __decorate([
        core_1.Input('rowsHeight')
    ], jqxSchedulerComponent.prototype, "attrRowsHeight", void 0);
    __decorate([
        core_1.Input('showToolbar')
    ], jqxSchedulerComponent.prototype, "attrShowToolbar", void 0);
    __decorate([
        core_1.Input('showLegend')
    ], jqxSchedulerComponent.prototype, "attrShowLegend", void 0);
    __decorate([
        core_1.Input('showCurrent')
    ], jqxSchedulerComponent.prototype, "attrShowCurrent", void 0);
    __decorate([
        core_1.Input('showCurrentAppointment')
    ], jqxSchedulerComponent.prototype, "attrShowCurrentAppointment", void 0);
    __decorate([
        core_1.Input('scrollBarSize')
    ], jqxSchedulerComponent.prototype, "attrScrollBarSize", void 0);
    __decorate([
        core_1.Input('source')
    ], jqxSchedulerComponent.prototype, "attrSource", void 0);
    __decorate([
        core_1.Input('statuses')
    ], jqxSchedulerComponent.prototype, "attrStatuses", void 0);
    __decorate([
        core_1.Input('touchRowsHeight')
    ], jqxSchedulerComponent.prototype, "attrTouchRowsHeight", void 0);
    __decorate([
        core_1.Input('theme')
    ], jqxSchedulerComponent.prototype, "attrTheme", void 0);
    __decorate([
        core_1.Input('touchAppointmentsMinHeight')
    ], jqxSchedulerComponent.prototype, "attrTouchAppointmentsMinHeight", void 0);
    __decorate([
        core_1.Input('touchScrollBarSize')
    ], jqxSchedulerComponent.prototype, "attrTouchScrollBarSize", void 0);
    __decorate([
        core_1.Input('timeZone')
    ], jqxSchedulerComponent.prototype, "attrTimeZone", void 0);
    __decorate([
        core_1.Input('touchDayNameFormat')
    ], jqxSchedulerComponent.prototype, "attrTouchDayNameFormat", void 0);
    __decorate([
        core_1.Input('toolBarRangeFormat')
    ], jqxSchedulerComponent.prototype, "attrToolBarRangeFormat", void 0);
    __decorate([
        core_1.Input('toolBarRangeFormatAbbr')
    ], jqxSchedulerComponent.prototype, "attrToolBarRangeFormatAbbr", void 0);
    __decorate([
        core_1.Input('toolbarHeight')
    ], jqxSchedulerComponent.prototype, "attrToolbarHeight", void 0);
    __decorate([
        core_1.Input('views')
    ], jqxSchedulerComponent.prototype, "attrViews", void 0);
    __decorate([
        core_1.Input('view')
    ], jqxSchedulerComponent.prototype, "attrView", void 0);
    __decorate([
        core_1.Input('width')
    ], jqxSchedulerComponent.prototype, "attrWidth", void 0);
    __decorate([
        core_1.Input('height')
    ], jqxSchedulerComponent.prototype, "attrHeight", void 0);
    __decorate([
        core_1.Input('auto-create')
    ], jqxSchedulerComponent.prototype, "autoCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onAppointmentChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onAppointmentClick", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onAppointmentDoubleClick", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onAppointmentDelete", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onAppointmentAdd", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onBindingComplete", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onCellClick", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onCellDoubleClick", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onContextMenuOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onContextMenuClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onContextMenuItemClick", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onContextMenuCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onDateChange", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onEditRecurrenceDialogOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onEditRecurrenceDialogClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onEditDialogCreate", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onEditDialogOpen", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onEditDialogClose", void 0);
    __decorate([
        core_1.Output()
    ], jqxSchedulerComponent.prototype, "onViewChange", void 0);
    jqxSchedulerComponent = __decorate([
        core_1.Component({
            selector: 'jqxScheduler',
            template: '<div><ng-content></ng-content></div>'
        })
    ], jqxSchedulerComponent);
    return jqxSchedulerComponent;
}()); //jqxSchedulerComponent
exports.jqxSchedulerComponent = jqxSchedulerComponent;
