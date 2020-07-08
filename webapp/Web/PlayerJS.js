//取得document object
var audio = document.getElementById("audio");
var song = document.getElementById("song");
var ControlPanel = document.getElementById("ControlPanel");
var info = document.getElementById("info");
var info2 = document.getElementById("info2");
var music = document.getElementById("music");
var vol = document.getElementById("vol");
var volM = document.getElementById("volM");
var volP = document.getElementById("volP");
var volValue = document.getElementById("volValue");
var duration = document.getElementById("duration");
var progress = document.getElementById("progress");
var Sbook = document.getElementById("Sbook");
var Tbook = document.getElementById("Tbook");


//加入事件監聽器
ControlPanel.addEventListener("click", objEvent);
music.addEventListener("change", function () { ChangeMusic(music.selectedIndex); });
vol.addEventListener(browserTest(), VolumeChange);
volM.addEventListener("click", function () { VolumeBtnChange(-1); });
volP.addEventListener("click", function () { VolumeBtnChange(1); });
progress.addEventListener(browserTest(), setTimerBar);
Tbook.addEventListener("drop", drop);
Tbook.addEventListener("dragover", allowDrop);
Sbook.addEventListener("dragstart", drag);

Sbook.addEventListener("drop", drop);
Sbook.addEventListener("dragover", allowDrop);
Tbook.addEventListener("dragstart", drag);

//判斷要執行哪一個功能
function objEvent(evt) {
    obj = evt.target;  //抓使用者在控制面板上點到的按鈕
    //alert(obj.id);
    //console.log(obj.id);
    switch (obj.id) {
        case "play":
            PlayMusic(obj);
            break;
        case "pause":
            PauseMusic(obj);
            break;
        case "stop":
            StopMusic(obj);
            break;
        case "prevtime":
            PrevTime();
            break;
        case "nexttime":
            NextTime();
            break;
        case "prevsong":
            SongChange(-1);
            break;
        case "nextsong":
            SongChange(1);
            break;
        case "muted":
            setMuted(audio.muted);
            break;
        case "random":
        case "loop":
        case "allloop":
            songState(obj);
            break;
        case "btnUpdateMusic":
            UpdateMusic();
            break;
        case "songbook":
            ShowBook();
            break;

    }
}

//document.write(navigator.userAgent);

function browserTest() {
    if (navigator.userAgent.search("Chrome") != -1)
        return "input";
    else if (navigator.userAgent.search("Firefox") != -1)
        return "input";
    else if (navigator.userAgent.search("OPR") != -1)
        return "input";
    else
        return "change";
    //console.log(navigator.userAgent);
}


function ShowBook() {
    display = Sbook.className == "show" ? "hide" : "show";
    Sbook.className = display;
    Tbook.className = display;
    btnUpdateMusic.className = display;
}

function UpdateMusic() {
    //alert('tt');
    for (i = music.children.length - 1; i >= 0; i--) {
        //console.log(i);
        music.removeChild(music.children[i]);

    }

    //console.log(Tbook.children.length);

    for (i = 0; i < Tbook.children.length; i++) {
        console.log(Tbook.children.length);
        console.log(i);
        Tnode = Tbook.children[i];
        option = document.createElement("option");
        option.value = Tnode.title;
        option.innerText = Tnode.innerText;
        music.appendChild(option);
    }
    ChangeMusic(0);
}



//處理允許丟入div的功能
function allowDrop(ev) {
    ev.preventDefault();
}
//處理抓取div的歌
function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}
//處理丟入div的歌
function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
}

DefaultSong();

function DefaultSong() {
    for (i = 0; i < Sbook.children.length; i++) {

        Snode = Sbook.children[i];
        option = document.createElement("option");
        option.value = Snode.title;
        option.innerText = Snode.innerText;
        music.appendChild(option);

        Snode.draggable = true;
        Snode.id = "song" + (i + 1);

    }
    ChangeMusic(0);
}


//以進度bar操作歌曲時間
function setTimerBar(evt) {
    //audio.currentTime= evt.offsetX / ControlPanel.clientWidth * audio.duration;
    audio.currentTime = progress.value;
}


function songState(obj) {
    if (info2.innerText == obj.title)
        info2.innerText = "";
    else
        info2.innerText = obj.title;
}

//將時間從秒數轉換為幾分幾秒
function getTimeFormat(timeSec) {
    min = Math.floor(timeSec / 60);
    sec = timeSec % 60;
    min = min < 10 ? "0" + min : min;
    sec = sec < 10 ? "0" + sec : sec;

    return min + ":" + sec;
}

//取得目前播放時間
function getDuration() {
    songDuration = Math.floor(audio.duration); //取得歌曲總長度(秒)
    songCurrentTime = Math.floor(audio.currentTime); //取得歌曲目前時間(秒)
    duration.innerText = getTimeFormat(songCurrentTime) + " / " + getTimeFormat(songDuration);
    progress.max = audio.duration;
    progress.value = audio.currentTime;

    w = (audio.currentTime / audio.duration * 100) + "%";
    progress.style.backgroundImage = "-webkit-linear-gradient(left,#b70000,#b70000 " + w + ", #c4c3c3 " + w + ",#c4c3c3)";

    //console.log(progress.children[0].style.width);
    //console.log("currentTime="+songCurrentTime);

    if (songDuration == songCurrentTime) {
        i = PlayState();
        if (music.selectedIndex == music.options.length - 1)
            i = IsAllLoop();

        if (i > -1)
            ChangeMusic(i);
        else
            StopMusic(ControlPanel.children[3]);

    }
    else
        setTimeout(getDuration, 1);
}

//確認播放狀態
function PlayState() {

    switch (info2.innerText) {
        case "隨機播放":
            index = Math.floor(Math.random() * music.options.length);
            break;
        case "單曲循環":
            index = music.selectedIndex;
            break;
        default:
            index = music.selectedIndex + 1;
            break;
    }

    return index;

}
//確認播放狀態2
function IsAllLoop() {

    return info2.innerText == "" ? -1 : 0;

}
//設定初始音量
VolumeChange();

//靜音設定
function setMuted(bool) {
    audio.muted = !bool;
}


//用按鈕微調音量
function VolumeBtnChange(val) {
    vol.value = parseInt(vol.value) + val;
    VolumeChange();
}

//音量控制
function VolumeChange() {
    audio.volume = vol.value / 100;
    volValue.value = vol.value;

    volValue.value = vol.value;
    audio.volume = volValue.value / 100;
    z = volValue.value + "%";
    vol.style.backgroundImage = "-webkit-linear-gradient(left, #009d72, #009d72 " + z + " , #e4e4e4 " + z + ", #e4e4e4)";

}


//上一首下一首
function SongChange(val) {
    index = music.selectedIndex;
    index += val;
    //alert(index+=1);
    //console.log(index)
    ChangeMusic(index);


}

//換歌
function ChangeMusic(index) {
    song.src = music.options[index].value;
    song.title = music.options[index].innerText;
    music.options[index].selected = true;
    audio.currentTime = 0;
    console.log(audio.paused);
    if (audio.paused == false) {
        //console.log(audio.paused);
        PlayMusic(music.nextElementSibling.nextElementSibling);
    }
}

//開始播放
function PlayMusic(obj) {
    if (audio.currentTime == 0)
        audio.load();
    audio.play();
    info.innerText = "現正播放:" + song.title;
    obj.innerText = ";";
    obj.id = "pause";

    getDuration();
}

//暫停播放
function PauseMusic(obj) {
    audio.pause();
    info.innerText = "音樂暫停(" + song.title + ")";
    obj.innerText = "4";
    obj.id = "play";
}

//停止播放
function StopMusic(obj) {
    console.log(obj);
    PauseMusic(obj.previousElementSibling)
    audio.currentTime = 0;
    info.innerText = "音樂停止";

}

//倒轉
function PrevTime() {
    audio.currentTime -= 10;
}

//快轉
function NextTime() {
    audio.currentTime += 10;
}