var selectedvalue = [];
var resetflag = 0;
var UpData = [];
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
   

    columns =
    [
        { id: "MCPEResultId", name: "MCPEResultId", field: "MCPEResultId" },
        { id: "Module", name: "Module", field: "Module" },
        { id: "SystemName", name: "System", field: "SystemName" },
        { id: "User", name: "User", field: "User" },
        { id: "ReadyForRelease", name: "Ready For Release", field: "ReadyForRelease" },
        { id: "ReleasedBy", name: "Released By", field: "ReleasedBy" },
        { id: "ReferenceNumber", name: "Reference #", field: "ReferenceNumber" },
        { id: "DebitOrPurchaseAccNo", name: "Debit / Purchase AccNo", field: "DebitOrPurchaseAccNo" },
        { id: "DebitOrPurchaseCurrency", name: "Debit / Purchase Currency", field: "DebitOrPurchaseCurrency" },
        { id: "DebitOrPurchaseAmt", name: "Debit / Purchase Amt", field: "DebitOrPurchaseAmt" },
        { id: "CreditOrSellAccNo", name: "Credit / Sell AccNo", field: "CreditOrSellAccNo" },
        { id: "CreditOrSellCurrency", name: "Credit / Sell Currency", field: "CreditOrSellCurrency" },
        { id: "CreditOrSellAmount", name: "Credit / Sell Amount", field: "CreditOrSellAmount" },
        { id: "MCPEResult", name: "MCPE Result", field: "MCPEResult" },
        { id: "MCPEComments", name: "MCPE Comments", field: "MCPEComments" },
        { id: "ExceptionResult", name: "Ex.Mgt Result", field: "ExceptionResult" },
        { id: "ExceptionComments", name: "Ex.Mgt Comments", field: "ExceptionComments" },
        { id: "ValueDate", name: "Value Date", field: "ValueDate" },
        { id: "id", name: "", field: "id" }
    ];

  
    visiblecolumns =
  [

      { id: "Module", name: "Module", field: "Module" },
      { id: "SystemName", name: "System", field: "SystemName" },
      { id: "User", name: "User", field: "User" },
      { id: "ReadyForRelease", name: "Ready For Release", field: "ReadyForRelease" },
      { id: "ReleasedBy", name: "Released By", field: "ReleasedBy" },
      { id: "ReferenceNumber", name: "Reference #", field: "ReferenceNumber" },
      { id: "DebitOrPurchaseAccNo", name: "Debit / Purchase AccNo", field: "DebitOrPurchaseAccNo" },
      { id: "DebitOrPurchaseCurrency", name: "Debit / Purchase Currency", field: "DebitOrPurchaseCurrency" },
      { id: "DebitOrPurchaseAmt", name: "Debit / Purchase Amt", field: "DebitOrPurchaseAmt" },
      { id: "CreditOrSellAccNo", name: "Credit / Sell AccNo", field: "CreditOrSellAccNo" },
      { id: "CreditOrSellCurrency", name: "Credit / Sell Currency", field: "CreditOrSellCurrency" },
      { id: "CreditOrSellAmount", name: "Credit / Sell Amount", field: "CreditOrSellAmount" },
            { id: "MCPEResult", name: "MCPE Result", field: "MCPEResult" },
      { id: "MCPEComments", name: "MCPE Comments", field: "MCPEComments" },
      { id: "ExceptionResult", name: "Ex.Mgt Result", field: "ExceptionResult" },
      { id: "ExceptionComments", name: "Ex.Mgt Comments", field: "ExceptionComments" },
      { id: "ValueDate", name: "Value Date", field: "ValueDate" }

     
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
           
        }

    });

    grid.onDblClick.subscribe(function (e, args) {
        clearAllMessages();




        if (grid.getActiveCell() != null) {

            selectedvalue[0] = dataView.getItem(grid.getActiveCell().row)[idfield];
            selectedvalue[1] = dataView.getItem(grid.getActiveCell().row).ScenarioName;
            setfooter(gridContainerDiv, grid.getActiveCell().row + 1, dataView.getLength());
           
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
           
        }
    });

    grid.onSort.subscribe(function (e, args) {
        SortGrid(args, dataView);
        grid.setActiveCell(0, 0);

    });
    FilterGridWithRowCount(grid, dataView, gridContainerDiv);
    $(grid.getHeaderRow()).click(function () {
       
    });

    grid.init();
    if (data.length == 0) {
        data = [];

        setfooter(gridContainerDiv, 0, 0);
       
    }
    else {
        selectedvalue[0] = data[0.0][idfield];             //  selectedvalue = data[cell.row][idfield];
        selectedvalue[1] = data[0.0].ScenarioName;
        setfooter(gridContainerDiv, 1, dataView.getLength());
        
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







//function setGridParameters() {
//    //showing empty grid

//    gridContainerDiv = "#grdAllocation";
//    ToggleButton = "#viewdetails";


//    columns =
//    [
//        { id: "Module", name: "Module", field: "Module" },
//         { id: "System", name: "System", field: "SystemName" },
//         { id: "AllocatedTo", name: "Tester", field: "User" },
//         { id: "ReadyForRelease", name: "Ready For Release", field: "ReadyForRelease" },
//         { id: "DebitOrPurchaseAccNo", name: "Debit/Purchase AccNo", field: "DebitOrPurchaseAccNo" },
//          { id: "DebitOrPurchaseAmt", name: "DebitOrPurchase Amt", field: "DebitOrPurchaseAmt" },
//       { id: "DebitOrPurchaseCurrency", name: "Debit/Purchase Currency", field: "DebitOrPurchaseCurrency" },
//       { id: "CreditOrSellAccNo", name: "Credit/Sell AccNo", field: "CreditOrSellAccNo" },
//          { id: "CreditOrSellCurrency", name: "Credit/Sell Currency", field: "CreditOrSellCurrency" },
//       { id: "CreditOrSellAmount", name: "Credit/SellAmount", field: "CreditOrSellAmount" },
//       { id: "ValueDate", name: "Value Date", field: "ValueDate" ,formatter: Slick.Formatters.Date},
//        { id: "id", name: "", field: "id", visible: false, width: 0, minWidth: 0, maxWidth: 0, cssClass: "reallyHidden" }
//    ];





//    visiblecolumns = null;

//    options =
//    {
//        enableCellNavigation: true,
//        enableColumnReorder: false,
//        forceFitColumns: true,
//        multiColumnSort: true,
//        editable: true,
//        asyncEditorLoading: false,
//        showHeaderRow: true,
//        explicitInitialization: true,
//        headerRowHeight: 30
//    };


//    idfield = "id";
//    gridwidth = 500;
//    gridheight = 600;
//}





function PassMCPE() {

    var    selectedIndexes;
    selectedIndexes = grid.getSelectedRows();
    jQuery.each(selectedIndexes, function (index, value) {
        UpData.push(grid.getData().getItem(value));
    });

    for (var i = 0; i < UpData.length; i++) {
        UpData[i].MCPEResultId = 1;
    }
    PostData();
   
}

function FailMCPE() {

    var selectedIndexes;
    selectedIndexes = grid.getSelectedRows();
    jQuery.each(selectedIndexes, function (index, value) {
        UpData.push(grid.getData().getItem(value));
    });
    for (var i = 0; i < UpData.length; i++) {
        UpData[i].MCPEResultId = 2;
    }

    PostData();

}

function NAMCPE() {

    var selectedIndexes;
    selectedIndexes = grid.getSelectedRows();
    jQuery.each(selectedIndexes, function (index, value) {
        UpData.push(grid.getData().getItem(value));
    });
    for (var i = 0; i < UpData.length; i++) {
        UpData[i].MCPEResultId = 7;
    }

    PostData();

}

function QueryTesterMCPE() {

    var selectedIndexes;
    selectedIndexes = grid.getSelectedRows();
    jQuery.each(selectedIndexes, function (index, value) {
        UpData.push(grid.getData().getItem(value));
    });

    for (var i = 0; i < UpData.length; i++) {
        UpData[i].MCPEResultId = 6;
    }

    PostData();

}




//// This function will pass data (new & updated records) to controller 
function PostData() {
    $.noty.closeAll();
    var dataToSend = JSON.stringify(UpData);
    $.ajax({
        url: UpdateMCPE,
        type: "POST",
        data: dataToSend,
        dataType: "json",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data != null) {

                showMessage("Save Successful", "success");
                
                dataView.refresh();
                UpData = [];
                newRoleList = [];
                grid.setActiveCell(0, 0);
                grid.editActiveCell();
               
            }
        },
        error: function () {
            
            $.noty.closeAll();
            noty({
                text: "Error", type: 'error', dismissQueue: true,
                layout: 'bottom', theme: 'defaultTheme'
            });
        }
    });
}
