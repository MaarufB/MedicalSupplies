
    function updateTime() {
            var currentDate = new Date();
    var date = currentDate.toDateString();
    var time = currentDate.toLocaleTimeString();
    var dateElement = document.querySelector('.date');
    var timeElement = document.querySelector('.time');
    dateElement.textContent = date;
    timeElement.textContent = time;
        }

    // Update the time every second
    setInterval(updateTime, 1000);

    // Initial update
    updateTime();
