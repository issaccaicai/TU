"use script";
function makeMyTransGallery(id, picList) {
    var galleryEle = document.getElementById(id); 
    var large = document.getElementById("bigImage"); 
    var smallList = document.getElementById("picList");
    var caption = document.getElementById("picCap");  
    var bigPic = document.createElement("img");  

    bigPic.src = picList[0].imgFileName;
    large.appendChild(bigPic);
    caption.innerHTML = picList[0].caption;

    for (var i = 0; i < picList.length; i++) {
        {
            var images = document.createElement("img"); 
            images.src = picList[i].imgFileName;
            images.caption = picList[i].caption;
            smallList.appendChild(images);

            images.onclick = function () {
                bigPic.src = this.src;
                caption.innerHTML = this.caption;
            };
        }
    }
}

function makeMyTransGallery2(id, pic) {
    var galleryEle = document.getElementById(id); 
    var larg = document.getElementById("big"); 
    var smallLis = document.getElementById("pic");
    var captio = document.getElementById("picC");  
    var bigPi = document.createElement("img");  

    bigPi.src = pic[0].imgFileName;
    larg.appendChild(bigPi);
    captio.innerHTML = pic[0].caption;

    for (var i = 0; i < pic.length; i++) {
        {
            var images = document.createElement("img"); 
            images.src = pic[i].imgFileName;
            images.caption = pic[i].caption;
            smallLis.appendChild(images);

            images.onclick = function () {
                bigPi.src = this.src;
                captio.innerHTML = this.caption;
            };
        }
    }
}









