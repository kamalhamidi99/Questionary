import axios from 'axios';

//const BaseUrl = 'https://localhost:44318'
const BaseUrl = 'https://localhost:5002'

export function postData(url, params, callback) {
    axios.post(BaseUrl + url, params)
        .then(response => {
            if (response.status !== 200) {
                alert("Error!")
                console.log(response)
                return
            }
            callback(response)
        })
        .catch(err => {
            alert("Error!")
            console.log(err)
        });
}

export function getData(url, params, callback) {
    axios.get(BaseUrl + url, params)
        .then(response => {
            if (response.status !== 200) {
                alert("Error!")
                console.log(response)
                return
            }
            callback(response)
        })
        .catch(err => {
            alert("Error!")
            console.log(err)
        });
}

export function putData(url, params, callback) {
    axios.put(BaseUrl + url, params)
        .then(response => {
            if (response.status !== 200) {
                alert("Error!")
                console.log(response)
                return
            }
            callback(response)
        })
        .catch(err => {
            alert("Error!")
            console.log(err)
        });
}
