var selectedvalue = [];
var resetflag = 0;

var DMNumber_searchvalue;
var contractnovalue;
var statusvalue;
var amortizationvalue;
var fromdatevalue;
var todatevalue;
var baseaddress;

var selectedDMNo;

var gridContainerDiv;
var ToggleButton;
var columns;
var options;
var actionParameters;
var idfield;
var gridwidth;
var gridheight;
var emptyrow = [];
var visiblecolumns;
var dataView;
var columnFilters = {};



$(function () {

    baseaddress = (document.getElementById('viewdetailsLink')).href;
    setGridParameters();
    DisplayGrid("");
    ShowProgressBar();
    getAllocation();
    RemoveProgressBar();
   

});

function setGridParameters() {
    //showing empty grid

    gridContainerDiv = "#grdAllocation";
    ToggleButton = "#viewdetails";


    columns =
    [

        { id: "ScenarioName", name: "Scenario", field: "ScenarioName" },
        { id: "Description", name: "Description", field: "ScenarioDescription", width: 300 },
        { id: "Module", name: "Module", field: "Module" },
        { id: "System", name: "System", field: "SystemName" },
         { id: "AllcatedTo", name: "Allocated To", field: "User" },
        { id: "Planned", name: "Planned", field: "PlannedDate" },
        { id: "ReadyForRelease", name: "Ready For Release", field: "ReadyForRelease" },
        { id: "id", name: "", field: "id" }
    ];


    visiblecolumns = [

        { id: "ScenarioName", name: "Scenario", field: "ScenarioName" },
        { id: "Description", name: "Description", field: "ScenarioDescription", width: 300 },
        { id: "Module", name: "Module", field: "Module" },
        { id: "System", name: "System", field: "SystemName" },
         { id: "AllcatedTo", name: "Allocated To", field: "User" },
        { id: "Planned", name: "Planned", field: "PlannedDate" },
        { id: "ReadyForRelease", name: "Ready For Release", field: "ReadyForRelease" }

    ];

    options =
    {
        enableCellNavigation: true,
        enableColumnReorder: false,
        forceFitColumns: true,
        multiColumnSort: true,
        editable: true,
        asyncEditorLoading: false,
        showHeaderRow: true,
        explicitInitialization: true,
        rowHeight: 100,
        headerRowHeight: 30
    };


    idfield = "id";
    gridwidth = 500;
    gridheight = 600;
}



function getAllocation() {
    clearAllMessages();
    setGridParameters();
    ShowProgressBar();

    $.ajax({
        url: AllocationUrl,
        type: "GET",
        dataType: 'Json',
        cache: false,
        data: actionParameters,
        success: function (data) {
            if (data.length > 0) {
                if (data[0].id == null) {
                    showMessage("No matching records found.", "warning");
                    setfooter(gridContainerDiv, 0, 0);
                    DisplayGrid("");
                }
                else {
                   showMessage("Page Load Complete.", "success");
                    DisplayGrid(data);
                }
            }

        },
        error: function () {
            if ($.noty.closeAll()) {
                noty({
                    text: 'error fetching data.Please try again', type: 'warning', dismissQueue: false,
                    layout: 'bottom', theme: 'defaultTheme'
                });
            }
        }
    });                                //end of ajax call

    RemoveProgressBar();
}
function DisplayGrid(data) {
    gridwidth = $(gridContainerDiv).width();
    $(gridContainerDiv).css({ "width": gridwidth + "px", "height": gridheight });
    dataView = new Slick.Data.DataView();
    grid = new Slick.Grid(gridContainerDiv, dataView, columns, options);
    grid.setSelectionModel(new Slick.RowSelectionModel());
    grid.registerPlugin(new Slick.AutoTooltips());
    if (visiblecolumns != null) {
        grid.setColumns(visiblecolumns);
    }
    if ((grid.getSelectedRows() != null) && dataView.getItem(grid.getSelectedRows()) != null) {
        selectedvalue[0] = dataView.getItem(getSelectedRows()[0])[idfield];
        selectedvalue[1] = dataView.getItem(getSelectedRows()[0]).ScenarioName;
    }
    grid.onClick.subscribe(function (e, args) {
        clearAllMessages();


        if (grid.getActiveCell() != null) {

            selectedvalue[0] = dataView.getItem(grid.getActiveCell().row)[idfield];
            selectedvalue[1] = dataView.getItem(grid.getActiveCell().row).ScenarioName;
            setfooter(gridContainerDiv, grid.getActiveCell().row + 1, dataView.getLength());
            DisableToggleButton(ToggleButton, false);
        }

    });

    grid.onDblClick.subscribe(function (e, args) {
        clearAllMessages();




        if (grid.getActiveCell() != null) {

            selectedvalue[0] = dataView.getItem(grid.getActiveCell().row)[idfield];
            selectedvalue[1] = dataView.getItem(grid.getActiveCell().row).ScenarioName;
            setfooter(gridContainerDiv, grid.getActiveCell().row + 1, dataView.getLength());
            DisableToggleButton(ToggleButton, false);
           
            InitializeDialog($("#AllocationDetailsdialog"));
            $("#AllocationDetailsdialog").dialog("open");
            RemoveProgressBar();
        }

    });

    grid.onSelectedRowsChanged.subscribe(function (e, args) {

        if (grid.getActiveCell() != null) {
            selectedvalue[0] = dataView.getItem(grid.getActiveCell().row)[idfield];
            selectedvalue[1] = dataView.getItem(grid.getActiveCell().row).ScenarioName;
            setfooter(gridContainerDiv, grid.getActiveCell().row + 1, dataView.getLength());
            DisableToggleButton(ToggleButton, false);
        }
    });

    grid.onSort.subscribe(function (e, args) {
        SortGrid(args, dataView);
        grid.setActiveCell(0, 0);

    });
    FilterGridWithRowCount(grid, dataView, gridContainerDiv);
    $(grid.getHeaderRow()).click(function () {
        DisableToggleButton(ToggleButton, true);
    });

    grid.init();
    if (data.length == 0) {
        data = [];

        setfooter(gridContainerDiv, 0, 0);
        DisableToggleButton(ToggleButton, true);
    }
    else {
        selectedvalue[0] = data[0.0][idfield];             //  selectedvalue = data[cell.row][idfield];
        selectedvalue[1] = data[0.0].ScenarioName;
        setfooter(gridContainerDiv, 1, dataView.getLength());
        DisableToggleButton(ToggleButton, false);
    }
    dataView.beginUpdate();
    dataView.setItems(data, 'id');
    dataView.setFilter(filter);
    var rows = [];
    rows.push(0);

    setfooter(gridContainerDiv, 1, dataView.getLength());
    grid.setSelectedRows(rows);
    dataView.endUpdate();
    grid.gotoCell(0, 0);
}


//Method to Initialize the DialogBox
function InitializeDialog($element) {

    var gridwidth = $(window).width() - 100;
    var gridheight = $(window).height() - 150;
    CreateLookupHtml(gridheight, gridwidth);

    $element.dialog({
        autoOpen: false,
        height: gridheight + 50,
        width: gridwidth + 15,
        resizable: true,
        draggable: true,

        model: true,
        show: 'slide',
        closeText: 'x',
        dialogClass: 'alert',
        closeOnEscape: true,
        open: function (event, ui) {
            //Load the Partial View Here using Controller and Action
            ShowProgressBar();
            SetDialogStyles("Update Scenario Details");
            $element.load(baseaddress + '?id=' + selectedvalue[0]);

        },

        close: function () {
            $(this).dialog('close');
        }

    });

}


