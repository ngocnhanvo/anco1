"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.teamSalesContacts = '<tr><td style="width: 100px;"><img src="../images/janet.png" /></td><td style=""><strong>Team lead:</strong> Petra Wilson<br /><strong>Phone: </strong>555-313-899<br /><strong>Email: </strong>petraw@company.com</td></tr>', exports.teamSalesStaff = '<strong>Petra Wilson</strong> Team lead, Phone: 555-313-899<br /><strong>Jenny Oswald</strong> Marketing consultant, Phone: 555-313-333<br /><strong>Peter Tennant</strong> Accountant, Phone: 555-313-161', exports.teamSupportContacts = '<tr><td style="width: 100px;"><img src="../images/steven.png" /></td><td style=""><strong>Team lead:</strong> Michael Nagase<br /><strong>Phone: </strong>555-313-643<br /><strong>Email: </strong>nagase@company.com</td></tr>', exports.teamSupportStaff = '<strong>Michael Nagase</strong> Team lead, Phone: 555-313-643<br /><strong>Sam Forrester</strong> Chief support officer, Phone: 555-313-644<br /><strong>Dean Milhouse</strong> Support officer, Phone: 555-313-188', exports.teamSalesProjects = ['2015 marketing research', 'Advertisement revenue increase'], exports.teamSupportProjects = ['Governmental support task', 'Conference preparation', 'HelloCompany support task'], exports.teamSalesProjectsTimeline = '<strong>January - December</strong><br />&nbsp;2015 marketing research<br /><br /><strong>February - June</strong><br />&nbsp;Advertisement revenue increase', exports.teamSupportProjectsTimeline = '<strong>September - December</strong><br />&nbsp;Governmental support task<br /><br /><strong>July - August</strong><br />&nbsp;Conference preparation<br /><br /><strong>January - December</strong><br />&nbsp;HelloCompany support task', exports.project1Data = [{ Month: 'January', Resources: 50, Issues: 2 }, { Month: 'February', Resources: 90, Issues: 7 }, { Month: 'March', Resources: 93, Issues: 15 }, { Month: 'April', Resources: 70, Issues: 36 }, { Month: 'May', Resources: 70, Issues: 20 }, { Month: 'June', Resources: 70, Issues: 20 }, { Month: 'July', Resources: 68, Issues: 16 }, { Month: 'August', Resources: 69, Issues: 9 }, { Month: 'September', Resources: 33, Issues: 2 }, { Month: 'October', Resources: 50, Issues: 0 }, { Month: 'November', Resources: 13, Issues: 0 }, { Month: 'December', Resources: 20, Issues: 0 }], exports.project2Data = [{ Month: 'January', Resources: null, Issues: null }, { Month: 'February', Resources: 90, Issues: 38 }, { Month: 'March', Resources: 100, Issues: 45 }, { Month: 'April', Resources: 80, Issues: 13 }, { Month: 'May', Resources: 27, Issues: 11 }, { Month: 'June', Resources: 20, Issues: 7 }, { Month: 'July', Resources: null, Issues: null }, { Month: 'August', Resources: null, Issues: null }, { Month: 'September', Resources: null, Issues: null }, { Month: 'October', Resources: null, Issues: null }, { Month: 'November', Resources: null, Issues: null }, { Month: 'December', Resources: null, Issues: null }], exports.project3Data = [{ Month: 'January', Resources: null, Issues: null }, { Month: 'February', Resources: null, Issues: null }, { Month: 'March', Resources: null, Issues: null }, { Month: 'April', Resources: null, Issues: null }, { Month: 'May', Resources: null, Issues: null }, { Month: 'June', Resources: null, Issues: null }, { Month: 'July', Resources: null, Issues: null }, { Month: 'August', Resources: null, Issues: null }, { Month: 'September', Resources: 10, Issues: 1 }, { Month: 'October', Resources: 80, Issues: 15 }, { Month: 'November', Resources: 99, Issues: 30 }, { Month: 'December', Resources: 20, Issues: 0 }], exports.project4Data = [{ Month: 'January', Resources: null, Issues: null }, { Month: 'February', Resources: null, Issues: null }, { Month: 'March', Resources: null, Issues: null }, { Month: 'April', Resources: null, Issues: null }, { Month: 'May', Resources: null, Issues: null }, { Month: 'June', Resources: null, Issues: null }, { Month: 'July', Resources: 70, Issues: 3 }, { Month: 'August', Resources: 11, Issues: 5 }, { Month: 'September', Resources: null, Issues: null }, { Month: 'October', Resources: null, Issues: null }, { Month: 'November', Resources: null, Issues: null }, { Month: 'December', Resources: null, Issues: null }], exports.project5Data = [{ Month: 'January', Resources: 20, Issues: 0 }, { Month: 'February', Resources: 20, Issues: 2 }, { Month: 'March', Resources: 33, Issues: 12 }, { Month: 'April', Resources: 42, Issues: 16 }, { Month: 'May', Resources: 80, Issues: 24 }, { Month: 'June', Resources: 78, Issues: 28 }, { Month: 'July', Resources: 68, Issues: 16 }, { Month: 'August', Resources: 10, Issues: 2 }, { Month: 'September', Resources: 47, Issues: 12 }, { Month: 'October', Resources: 50, Issues: 10 }, { Month: 'November', Resources: 8, Issues: 1 }, { Month: 'December', Resources: 15, Issues: 3 }], exports.team = 'Sales';
function initTeamDataTable() {
    var teamData = [{
            team: 'Sales Team',
            lead: 'Petra Wilson'
        }, {
            team: 'Support Team',
            lead: 'Michael Nagase'
        }];
    var source = {
        dataType: "json",
        dataFields: [{
                name: 'team',
                type: 'string'
            }, {
                name: 'lead',
                type: 'string'
            }],
        localdata: teamData
    };
    var dataAdapter = new $.jqx.dataAdapter(source);
    var teamTableOptions = {
        width: '100%',
        height: '100%',
        source: dataAdapter,
        ready: function () {
            setTimeout(function (_) { return teamsDataTable.selectRow(0); });
        },
        columns: [{
                text: 'Team',
                dataField: 'team',
                width: 120
            }, {
                text: 'Lead',
                dataField: 'lead'
            }]
    };
    var teamsDataTable = jqwidgets.createInstance('#teamsDataTable', 'jqxDataTable', teamTableOptions);
    teamsDataTable.addEventHandler('rowSelect', function (event) {
        var boundIndex = event.args.boundIndex, contacts, staff, projects, projectsTimeline, projectsHistory;
        if (boundIndex === 0) {
            exports.team = 'Sales';
            contacts = exports.teamSalesContacts;
            staff = exports.teamSalesStaff;
            projects = exports.teamSalesProjects;
            projectsTimeline = exports.teamSalesProjectsTimeline;
            projectsHistory = exports.project1Data;
        }
        else {
            exports.team = 'Support';
            contacts = exports.teamSupportContacts;
            staff = exports.teamSupportStaff;
            projects = exports.teamSupportProjects;
            projectsTimeline = exports.teamSupportProjectsTimeline;
            projectsHistory = exports.project3Data;
        }
        var contactsTable = document.getElementById('contactsTable');
        var staffDiv = document.getElementById('staffDiv');
        var projectsListBox = document.getElementById('projectsListBox');
        var projectsTimelineDiv = document.getElementById('projectsTimelineDiv');
        var projectHistoryChart = document.getElementById('projectHistoryChart');
        if (contactsTable) {
            contactsTable.innerHTML = contacts;
        }
        if (staffDiv) {
            staffDiv.innerHTML = staff;
        }
        if (projectsListBox) {
            var projectsListBox_1 = jqwidgets.createInstance('#projectsListBox', 'jqxListBox', { source: projects });
            projectsListBox_1.selectIndex(0);
        }
        if (projectsTimelineDiv) {
            projectsTimelineDiv.innerHTML = projectsTimeline;
        }
        if (projectHistoryChart) {
            jqwidgets.createInstance('#projectHistoryChart', 'jqxChart', { source: projectsHistory });
        }
    });
}
exports.initTeamDataTable = initTeamDataTable;
function initProjectsListBox() {
    var projectsListBoxOptions = {
        selectedIndex: 0,
        source: exports.teamSalesProjects,
        width: '100%',
        height: '100%'
    };
    var projectsListBox = jqwidgets.createInstance('#projectsListBox', 'jqxListBox', projectsListBoxOptions);
    var projectHistoryChart = document.getElementById('projectHistoryChart');
    projectsListBox.addEventHandler('select', function (event) {
        if (projectHistoryChart) {
            var args = event.args;
            if (args) {
                var label = args.item.label;
                switch (label) {
                    case '2015 marketing research':
                        jqwidgets.createInstance('#projectHistoryChart', 'jqxChart', { source: exports.project1Data });
                        break;
                    case 'Advertisement revenue increase':
                        jqwidgets.createInstance('#projectHistoryChart', 'jqxChart', { source: exports.project2Data });
                        break;
                    case 'Governmental support task':
                        jqwidgets.createInstance('#projectHistoryChart', 'jqxChart', { source: exports.project3Data });
                        break;
                    case 'Conference preparation':
                        jqwidgets.createInstance('#projectHistoryChart', 'jqxChart', { source: exports.project4Data });
                        break;
                    case 'HelloCompany support task':
                        jqwidgets.createInstance('#projectHistoryChart', 'jqxChart', { source: exports.project5Data });
                        break;
                }
            }
        }
    });
}
exports.initProjectsListBox = initProjectsListBox;
function initProjectHistoryChart() {
    var settings = {
        title: 'Project History',
        description: 'Overview of project resources and solved issues',
        showBorderLine: false,
        titlePadding: {
            left: 90,
            top: 0,
            right: 0,
            bottom: 10
        },
        source: exports.project1Data,
        xAxis: {
            dataField: 'Month',
            gridLines: {
                visible: false
            }
        },
        valueAxis: {
            minValue: 0,
            maxValue: 100,
            unitInterval: 10,
            description: 'Resources (in relative units)'
        },
        colorScheme: 'scheme05',
        seriesGroups: [{
                type: 'column',
                columnsGapPercent: 30,
                seriesGapPercent: 0,
                series: [{
                        dataField: 'Resources',
                        displayText: 'Resources spent'
                    }]
            }, {
                type: 'line',
                columnsGapPercent: 30,
                seriesGapPercent: 0,
                series: [{
                        dataField: 'Issues',
                        displayText: 'Issues'
                    }]
            }]
    };
    jqwidgets.createInstance('#projectHistoryChart', 'jqxChart', settings);
}
exports.initProjectHistoryChart = initProjectHistoryChart;
