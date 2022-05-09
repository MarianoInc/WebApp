window.onload = Login;

function Login(){
    document.getElementById("btn-login").addEventListener("click", Post);
}

async function Post(){
    let user = document.getElementById("username").value;
    let pass = document.getElementById("Password").value;

    if( user != "" && pass != ""){
        await axios({
            method: 'POST',
            url: 'https://localhost:5001/auth/login',
            data: {
                userName: user,
                password: pass
            }
        }).then(response =>{
            localStorage.setItem("Token", JSON.stringify(response.data.data.token));
            localStorage.setItem("UserName", JSON.stringify(response.data.data.userName));
            console.log(response);
            if(localStorage.getItem("Token")){
                location.replace("/Pages/RegisterClient.html");
            }
        }).catch(response => {console.log(response.Message + "Failed to login.")});
        
    }
                       
}
