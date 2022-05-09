window.onload = Main;

var Properties = {};

function Main(){
    TokenVerifier();
    document.getElementById("statusclients").onload = Get();
    document.getElementById("btn-read-field").addEventListener("click", Get);
    document.getElementById("log-out").addEventListener("click", LogOut);
    document.getElementById("btn-new-field").addEventListener("click", GenerateProperty);
    document.getElementById("create").addEventListener("click", Post);
    document.getElementById("update").addEventListener("click", Put)
    document.getElementById("delete").addEventListener("click", Delete);
}

function TokenVerifier(){
    if(!localStorage.getItem("Token")){
        LogOut();
    }
}

function LogOut(){
    localStorage.clear();
    location.replace("/index.html");
}

//Genera campo de propiedad adicional
function GenerateProperty(){
    let key = document.getElementById("key").value;
    let value = document.getElementById("value").value;
    
    if (key != '' && value != '') {
        Properties[key] = value;
        document.getElementById("Special").innerHTML = "";
        for (var prop in Properties) {
            document.getElementById("Special").innerHTML += `<div>${prop} | ${Properties[prop]}</div>`;
        }
    }
    else{
        alert("Invalid Fields"); 
    }
}

//CRUD
async function Get(){
    const jwtToken = JSON.parse(localStorage.getItem("Token"));
    let check = document.getElementById("statusclients").checked == true ? true : false;
    await axios({
        method: 'GET',
        url: 'https://localhost:5001/clients?clientState=' + check,
        headers: {
            Authorization: `Bearer ${jwtToken}` 
        }        
    })
    .then(response => {
        let objResponse = response.data;
        document.getElementById("ClientList").innerHTML = "";
        for (const iterator of objResponse) {            
            let self = () =>{
                var props = "";
                for (const key in iterator.properties) {
                     props += `${key}: ${iterator.properties[key]}<br/>`;
                }
                return props 
            }

            document.getElementById('ClientList').innerHTML += 
            `<div class="card border-radius margin" id="Card">
            ID: ${iterator.id}<br/>
            Name: ${iterator.fullName}<br/> 
            DNI: ${iterator.dni}<br/>
            Age: ${iterator.age}<br/>
            Gender: ${iterator.gender}<br/>
            Status: ${iterator.isActive == true ? "Active" : "Stand-By"}<br/>
            Diver License: ${iterator.driverLicense == true ? "Yes" : "No"}<br/>
            Use Glasses: ${iterator.useGlasses == true ? "Yes" : "No"}<br/>
            Is Diabetic: ${iterator.isDiabetic == true ? "Yes" : "No"}<br/>
            Other Diseases?: ${iterator.otherDiseases == true ? "Yes" : "No"}<br/>
            Disease: ${iterator.disease == null ? "None" : iterator.disease}<br/>
            ${iterator.properties == null ? "" : self()}            
            </div><br/>
            `;
        }
    })
    .catch((e) => {
        console.log(e);
    });
}



async function Post(){
    const jwtToken = JSON.parse(localStorage.getItem("Token"));

    await axios({
        method: 'POST',
        url: 'https://localhost:5001/clients',
        headers: {
            Authorization: `Bearer ${jwtToken}` 
        },
        data: {
            fullName: document.getElementById("FullName").value, 
            dni: +document.getElementById("DNI").value,
            age: +document.getElementById("Age").value,
            gender: document.getElementById("Gender").value,
            diverLicense: document.getElementById("DriverLicense").checked == true ? true : false,
            useGlasses: document.getElementById("UseGlasses").checked == true ? true : false,
            isDiabetic: document.getElementById("IsDiabetic").checked == true ? true : false,
            otherDiseases: document.getElementById("OtherDisease").checked == true ? true : false,
            disease: document.getElementById("Disease").value,
            properties: Properties
        }
    })
    .then(() =>{location.reload()})
    .catch((e) => {console.log(e)});
}

async function Put(){
    const jwtToken = JSON.parse(localStorage.getItem("Token"));
    await axios({
        method: "PUT",
        url: 'https://localhost:5001/clients',
        headers: {
            Authorization: `Bearer ${jwtToken}` 
        },
        data: {
            id: document.getElementById("Id").value,
            fullName: document.getElementById("FullName").value, 
            dni: +document.getElementById("DNI").value,
            age: +document.getElementById("Age").value,
            gender: document.getElementById("Gender").value,
            isActive: document.getElementById("IsActive").checked == true ? true : false,
            diverLicense: document.getElementById("DriverLicense").checked == true ? true : false,
            useGlasses: document.getElementById("UseGlasses").checked == true ? true : false,
            isDiabetic: document.getElementById("IsDiabetic").checked == true ? true : false,
            otherDiseases: document.getElementById("OtherDisease").checked == true ? true : false,
            disease: document.getElementById("Disease").value,
            properties: Properties
        }
    })
    .then(() =>{location.reload()})
    .catch(() => {alert("El artículo no se modificó de la db.")});
}

async function Delete(){

    if(document.getElementById("Id").value != null){
        const jwtToken = JSON.parse(localStorage.getItem("Token"));
        await axios({
            method: 'DELETE',
            url: 'https://localhost:5001/clients/'+ document.getElementById("Id").value,
            headers: {
                Authorization: `Bearer ${jwtToken}` 
            }      
        })
        .then(() =>{location.reload()})
        .catch(() => {alert("El artículo no se eliminó de la db.")});
    }
}