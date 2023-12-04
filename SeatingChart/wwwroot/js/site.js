


// var grid;

// var numCols = 2; 


// var cols = [
//     { field: 'Column1', headerText: '1' },
//     { field: 'Test', headerText: '2' },
//     // Add more columns as needed
// ];


// var data = [
//     { Column1: student_list[0].firstName + " " + student_list[0].middleName + " " + student_list[0].lastName },
//     { Column1: student_list[1].firstName, Column2: "Value4", Column3: "Value5" }, 
//     // Add more data as needed
// ];   

// var morestudents = [];

// Assuming you have referenced jQuery
// $(function () {
//   $.getJSON("/Data/SeatingChart", function (crewResponse) {
//     pirates = crewResponse.pirates;
//   });
// }); 







function createGrid() {
    var cols = [] 


    var data = student_list.map(function(student) { return {name: student.firstName + " " + student.middleName + " " + student.lastName}}); 
    
    
    grid = new ej.grids.Grid({
        dataSource: data,
        columns: cols, 
        gridLines: 'Both',
        selectionSettings: {mode: 'Cell', cellSelectionMode: 'Box'}  
        

    });
    grid.appendTo('#Grid'); 
    
}

function addRow() {
    var newRow = {};
    grid.dataSource.push(newRow);
    grid.refresh();
}

function deleteRow() {
    grid.dataSource.pop();
    grid.refresh();  
}

function addColumn() {
    // var newColumnName = prompt("Enter the name of the new column:");
    // if (newColumnName) {
        grid.destroy();
        numCols += 1;
        // cols.push({ field: newColumnName, headerText: newColumnName });
        createGrid();
    // }
}

function deleteColumn() {
    // var columnNameToDelete = prompt("Enter the name of the column to delete:");
    // if (columnNameToDelete) {
        grid.destroy();
        numCols -= 1;

        // cols = cols.filter(column => column.field !== columnNameToDelete);
        createGrid();
    // }
}

createGrid();

document.getElementById('addRowBtn').addEventListener('click', addRow);
document.getElementById('deleteRowBtn').addEventListener('click', deleteRow);
document.getElementById('addColumnBtn').addEventListener('click', addColumn);
document.getElementById('deleteColumnBtn').addEventListener('click', deleteColumn);