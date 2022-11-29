let jobs = [];
let weapons = [];
let armors = [];
let connection = null;
let jobIdToUpdate = -1;
let weaponIdToUpdate = -1;
let armorIdToUpdate = -1;

jobgetdata();
weapongetdata();
armorgetdata();

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:30703/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("JobCreated", (user, message) => {
        jobgetdata();
    });

    connection.on("JobDeleted", (user, message) => {
        jobgetdata();
    });

    connection.on("JobUpdated", (user, message) => {
        jobgetdata();
    });

    connection.on("WeaponCreated", (user, message) => {
        weapongetdata();
    });

    connection.on("WeaponDeleted", (user, message) => {
        weapongetdata();
    });

    connection.on("WeaponUpdated", (user, message) => {
        weapongetdata();
    });

    connection.on("ArmorCreated", (user, message) => {
        armorgetdata();
    });

    connection.on("ArmorDeleted", (user, message) => {
        armorgetdata();
    });

    connection.on("ArmorUpdated", (user, message) => {
        armorgetdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

/*Show functions Done*/
function showjobs() {
    document.getElementById('jobs').style.display = 'contents';
    document.getElementById('weapons').style.display = 'none';
    document.getElementById('armors').style.display = 'none';
}

function showweapons() {
    document.getElementById('jobs').style.display = 'none';
    document.getElementById('weapons').style.display = 'contents';
    document.getElementById('armors').style.display = 'none';
}

function showarmors() {
    document.getElementById('jobs').style.display = 'none';
    document.getElementById('weapons').style.display = 'none';
    document.getElementById('armors').style.display = 'contents';
}
/*Show functions*/
/*GetData functions*/
async function jobgetdata() {
    await fetch('http://localhost:30703/job')
        .then(x => x.json())
        .then(y => {
            jobs = y;
            //console.log(actors);
            Jobdisplay();
        });
}

async function weapongetdata() {
    await fetch('http://localhost:30703/weapon')
        .then(x => x.json())
        .then(y => {
            weapons = y;
           //console.log(weapons);
            Weapondisplay();
        });
}

async function armorgetdata() {
    await fetch('http://localhost:30703/armor')
        .then(x => x.json())
        .then(y => {
            armors = y;
           // console.log(armors);
            Armordisplay();
        });
}
/*GetData functions*/

/*Display functions*/
function Jobdisplay() {
    document.getElementById('jobresultarea').innerHTML = "";
    jobs.forEach(t => {
        document.getElementById('jobresultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="jobremove(${t.id})">Delete</button>` +
            `<button type="button" onclick="jobshowupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function Weapondisplay() {
    document.getElementById('weaponresultarea').innerHTML = "";
    weapons.forEach(t => {
        document.getElementById('weaponresultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
        + t.name + "</td><td>" + t.baseDamage + "</td><td>" +
            `<button type="button" onclick="weaponremove(${t.id})">Delete</button>` +
            `<button type="button" onclick="weaponshowupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function Armordisplay() {
    document.getElementById('armorresultarea').innerHTML = "";
    armors.forEach(t => {
        document.getElementById('armorresultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" + t.baseDefense + "</td><td>" +
            `<button type="button" onclick="armorremove(${t.id})">Delete</button>` +
            `<button type="button" onclick="armorshowupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}
/*Display functions*/

/*Create functions*/
function jobcreate() {
    let jobname = document.getElementById('jobname').value;
    let asd = "TANK";
    fetch('http://localhost:30703/job', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: jobname, role: asd })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            jobgetdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function weaponcreate() {
    let jobname = document.getElementById('weaponname').value;
    let BaseD = 1;
    fetch('http://localhost:30703/weapon', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: jobname, basedamage: BaseD })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            weapongetdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function armorcreate() {
    let jobname = document.getElementById('armorname').value;
    let BaseD = 1;
    fetch('http://localhost:30703/armor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: jobname, basedefence: BaseD })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            armorgetdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
/*Create functions*/

/*Remove functions*/
function jobremove(id) {
    fetch('http://localhost:30703/job/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            jobgetdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function weaponremove(id) {
    fetch('http://localhost:30703/weapon/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            weapongetdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function armorremove(id) {
    fetch('http://localhost:30703/armor/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            armorgetdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
/*Remove functions*/

/*Update functions   SOMETHING IS FISHY*/ 
function jobupdate() {

    let jobname = document.getElementById('jobnametoupdate').value;
    let jobrole = document.getElementById('jobroletoupdate').value;
    fetch('http://localhost:30703/job', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: jobname, id: jobIdToUpdate, role: jobrole })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            jobgetdata();
        })
        .catch((error) => { console.error('Error:', error); });

    document.getElementById('Jobupdateformdiv').style.display = 'none';
}

function weaponupdate() {
    document.getElementById('weaponupdateformdiv').style.display = 'none';
    let jobname = document.getElementById('weaponnametoupdate').value;
    let weapondamage = document.getElementById('weapondamagetoupdate').value;
    fetch('http://localhost:30703/weapon', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: jobname, id: weaponIdToUpdate, baseDamage: weapondamage })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            weapongetdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function armorupdate() {
    document.getElementById('armorupdateformdiv').style.display = 'none';
    let jobname = document.getElementById('armornametoupdate').value;
    let baseDef = document.getElementById('armordefensetoupdate').value;
    fetch('http://localhost:30703/armor', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: jobname, id: armorIdToUpdate, baseDefense: baseDef })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            armorgetdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
/*Update functions*/

/*ShowUpdate functions SOMETHING IS FISHY*/
function jobshowupdate(id) {
    document.getElementById('jobnametoupdate').value = jobs.find(t => t['id'] == id)['name'];
    document.getElementById('jobroletoupdate').value = jobs.find(t => t['id'] == id)['role'];
    document.getElementById('Jobupdateformdiv').style.display = 'flex';
    jobIdToUpdate = id;
}

function weaponshowupdate(id) {
    document.getElementById('weaponnametoupdate').value = weapons.find(t => t['id'] == id)['name'];
    document.getElementById('weapondamagetoupdate').value = weapons.find(t => t['id'] == id)['baseDamage'];
    document.getElementById('weaponupdateformdiv').style.display = 'flex';
    weaponIdToUpdate = id;
}

function armorshowupdate(id) {
    document.getElementById('armornametoupdate').value = armors.find(t => t['id'] == id)['name'];
    document.getElementById('armordefensetoupdate').value = armors.find(t => t['id'] == id)['baseDefense'];
    document.getElementById('armorupdateformdiv').style.display = 'flex';
    armorIdToUpdate = id;
}
/*ShowUpdate functions*/




