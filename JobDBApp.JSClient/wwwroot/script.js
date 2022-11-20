let jobs = [];

fetch('http://localhost:30703/job')
    .then(x => x.json())
    .then(y => {
        jobs = y;
        console.log(jobs);
        display();
    });


function display() {

}

function create() {
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
        })
        .catch((error) => { console.error('Error:', error); });

}
function remove(id) {
    fetch('http://localhost:30703/job' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}