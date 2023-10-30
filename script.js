function makeGrid() {
    let tb1 = document.getElementById("pixelCanvas");

    for(let i = 0; i < 11; i++) {
        let myRow = document.createElement("tr");
        myRow.id = "row" + i;

        toolbar.appendChild(myRow);
        let rowW = document.getElementById("row" + i);
        
        for(let j= 0; j < 11; j ++){
            let myCell = document.createElement("td");
            rowW.appendChild(myCell); 
            

        }
    }
}