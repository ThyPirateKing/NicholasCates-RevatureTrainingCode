    // GET METHOD
    async function get(event, tableName){ // returns a promise
        return new Promise(function (resolve, reject) {
            if (event)
                event.preventDefault();
            var loginURL = 'http://localhost:4000/' + tableName;
            fetch(loginURL, {method: 'GET', headers:{'Content-Type':'application/json'}})
            .then(result => { 
                return result.json(); 
            })
            .then((result) => {
                console.log('in response: ', result);
                return resolve(result);
            })
            .catch(error => {
                console.log('error: ', error)
                return reject(error);
            });
        })
    }
    // POST METHOD
    async function post(event, tableName, ourBody){ // returns a promise
        return new Promise(function (resolve, reject) {
            if (event)
                event.preventDefault();
            var loginURL = 'http://localhost:4000/' + tableName;
            fetch(loginURL, {method: 'POST', 
                headers:{'Content-Type':'application/json'},
                body: ourBody // json in calling method
            })
            .then(result => { 
                return result.json(); 
            })
            .then((result) => {
                console.log('in response: ', result);
                return resolve(result);
            })
            .catch(error => {
                console.log('error: ', error)
                return reject(error);
            });
        })
    }
    // PUT METHOD (By ID)
    async function putByID(event, tableName, id, ourBody){ // returns a promise
        return new Promise(function (resolve, reject) {
            if (event)
                event.preventDefault();
            var loginURL = 'http://localhost:4000/' + tableName + '/' + id;
            fetch(loginURL, {method: 'PUT', 
                headers:{'Content-Type':'application/json'},
                body: ourBody // json in calling method
            })
            .then(result => { 
                return result.json(); 
            })
            .then((result) => {
                console.log('in response: ', result);
                return resolve(result);
            })
            .catch(error => {
                console.log('error: ', error)
                return reject(error);
            });
        })
    }
    // PUT METHOD (By Name)
    async function putByName(event, tableName, name, ourBody){ // returns a promise
        return new Promise(async function (resolve, reject) {
            if (event)
                event.preventDefault();
            await nameToID(tableName, name).then(response => {;
                var loginURL = 'http://localhost:4000/' + tableName + '/' + response;
                console.log("Created URL: " + loginURL);
                fetch(loginURL, {method: 'PUT', 
                    headers:{'Content-Type':'application/json'},
                    body: ourBody // json in calling method
                })
                .then(result => { 
                    return result.json(); 
                })
                .then((result) => {
                    console.log('in response: ', result);
                    return resolve(result);
                })
                .catch(error => {
                    console.log('error: ', error)
                    return reject(error);
                });
            })
        })
    }

    // DELETE METHOD (By ID)
    async function deleteByID(event, tableName, id){ // returns a promise
        return new Promise(function (resolve, reject) {
            if (event)
                event.preventDefault();
            var loginURL = 'http://localhost:4000/' + tableName + '/' + id;
            fetch(loginURL, {method: 'DELETE', 
                headers:{'Content-Type':'application/json'},
                body: id
            })
            .then(result => { 
                return result.json(); 
            })
            .then((result) => {
                console.log('in response: ', result);
                return resolve(result);
            })
            .catch(error => {
                console.log('error: ', error)
                return reject(error);
            });
        })
    }

    // DELETE METHOD (By Name)
    async function deleteByName(event, tableName, name){ // returns a promise
        return new Promise(async function (resolve, reject) {
            if (event)
                event.preventDefault();
            await nameToID(tableName, name).then(response => {;
                //console.log("ID received: " + response);
                var loginURL = 'http://localhost:4000/' + tableName + '/' + String(response);
                console.log("Created URL: " + loginURL);
                fetch(loginURL, {method: 'DELETE', 
                    headers:{'Content-Type':'application/json'},
                    body: name
                })
                .then(result => { 
                    return result.json(); 
                })
                .then((result) => {
                    console.log('in response: ', result);
                    return resolve(result);
                })
                .catch(error => {
                    console.log('error: ', error)
                    return reject(error);
                });
            })
        })
    }

    // Special Request Methods
    // EQUIP; BODY CAN ONLY BE NAME
    async function equip(event, ourBody){ // returns a promise
        return new Promise(function (resolve, reject) {
            if (event)
                event.preventDefault();
            var loginURL = 'http://localhost:4000/items';
            fetch(loginURL, {method: 'PATCH', 
                headers:{'Content-Type':'application/json'},
                body: ourBody // json in calling method
            })
            .then(result => { 
                return result.json(); 
            })
            .then((result) => {
                console.log('in response: ', result);
                return resolve(result);
            })
            .catch(error => {
                console.log('error: ', error)
                return reject(error);
            });
        })
    }
    
    // Helper Method
    async function nameToID(tablename, name){ // returns ID of name in tablename
        return new Promise(async function (resolve, reject){
            let names = []
            await get(event, tablename).then(async response => {
                for(var i = 0; i < response.length; i++){
                    //console.log(String(response[i].name) === String(name));
                    if (String(response[i].name) == String(name)){
                        console.log("Found id: " + response[i].id);
                        return resolve(response[i].id);
                    }
                    if (String(response[i].className) == String(name)){
                        console.log("Found id: " + response[i].id);
                        return resolve(response[i].id);
                    }
                }
            })
            return reject(new Error("Bad Name"));
        })
    }

    // Redirect
    function redirect(path){
        window.location.href = path;
    }


    // Start of DB verification functionality (Appending default values to DB)

    function verifyDB(){ // appends default entries to DB
        verifyItems();
        verifyClasses();
    }

    const defaultItems = [
        {
            "name":"DevWep",
            "weight":0.5,
            "value":1,
            "typeOfItem":"melee weapon"
        },
    ]
    async function verifyItems(){ // appends defaults
        let names = []
        await get(event, 'items').then(async response => {
            for(var i = 0; i < response.length; i++){
                names.push(response[i].name);
            }
            for (var j = 0; j < defaultItems.length; j++){
                if (!names.includes(defaultItems[j].name)){
                    try{
                        console.log(defaultItems[j].name, " was not found, appending with: ", defaultItems[j]);
                        await post(event,'items',JSON.stringify(defaultItems[j]));
                    } catch (err) {
                        console.log('verifydb error: ', err);
                    }
                }
            }
            console.log("Item verification complete.")
        })
    }

    const defaultClasses = [
        {
            "className":"Wizard",
            "dex":8,
            "str":10,
            "wis":14,
            "magic":12,
        },
        {
            "className":"Fighter",
            "dex":12,
            "str":14,
            "wis":10,
            "magic":8,
        },
        {
            "className":"Shadow Weaver",
            "dex":8,
            "str":10,
            "wis":12,
            "magic":14,
        }
    ]
    async function verifyClasses(){ // appends defaults
        let names = []
        await get(event, 'characterClasses').then(async response => {
            for(var i = 0; i < response.length; i++){
                names.push(response[i].className);
            }
            for (var j = 0; j < defaultClasses.length; j++){
                if (!names.includes(defaultClasses[j].className)){
                    try{
                        console.log(defaultClasses[j].className + " was not found, appending: ", defaultItems[j]);
                        await post(event,'characterClasses',JSON.stringify(defaultClasses[j]));
                    } catch (err) {
                        console.log('verifydb error: ', err);
                    }
                }
            }
            console.log("Class verification complete.")
        })
    }