!(function (o) {
    Array.prototype.forEach ||
        (o.forEach =
            o.forEach ||
            function (o, e) {
                for (var t = 0, r = this.length; t < r; t++) t in this && o.call(e, this[t], t, this);
            });
})(Array.prototype);
var mapObject,
    marker,
    markers = [],
    markersData = {
        Marker: [
            {
                location_latitude: 48.866024,
                location_longitude: 2.340041,
                listingimgURL: "single-listing-detail-1.html",
                listingImg: "assets/img/listing/l-2.png",
                authorURL: "author-detail.html",
                authorImg: "assets/img/t-1.png",
                listingcategoryURL: "listing-search-v1.html",
				listingCategory:"سالن عقد",
				listingURL:"single-listing-detail-1.html",
				listingTitle:"سالن عقد تشریفاتی الینا",
				listingLocation:"لیورپول، لندن انگلستان",
				listingCall:"09320000000",
				listingTime:"3 days ago",
				
            },
            {
                location_latitude: 48.86856,
                location_longitude: 2.349427,
                listingimgURL: "single-listing-detail-1.html",
                listingImg: "assets/img/listing/l-2.png",
                authorURL: "author-detail.html",
                authorImg: "assets/img/t-2.png",
                listingcategoryURL: "listing-search-v1.html",
				listingCategory:"SPORTS",
				listingURL:"single-listing-detail-1.html",
				listingTitle:"Decathlon Sport House",
				listingLocation:"لس آنجلس، آمریکا",
				listingCall:"+91 658 457 2156",
				listingTime:"1 روز پیش",
            },
            {
                location_latitude: 48.870824,
                location_longitude: 2.333005,
                listingimgURL: "single-listing-detail-1.html",
                listingImg: "assets/img/listing/l-2.png",
                authorURL: "author-detail.html",
                authorImg: "assets/img/t-3.png",
                listingcategoryURL: "listing-search-v1.html",
				listingCategory:"HOTELS",
				listingURL:"single-listing-detail-1.html",
				listingTitle:"The Gold Hotel Lalit",
				listingLocation:"کالیفرنیا، ایالات متحده آمریکا",
				listingCall:"09320000000",
				listingTime:"2 روز پیش",
            },
            {
                location_latitude: 48.864642,
                location_longitude: 2.345837,
                listingimgURL: "single-listing-detail-1.html",
                listingImg: "assets/img/listing/l-2.png",
                authorURL: "author-detail.html",
                authorImg: "assets/img/t-4.png",
                listingcategoryURL: "listing-search-v1.html",
				listingCategory:"ZYM & HEALTH",
				listingURL:"single-listing-detail-1.html",
				listingTitle:"Fitness Revolution Gym",
				listingLocation:"اوماها، انگلستان",
				listingCall:"09320000000",
				listingTime:"4 days ago",
            },
            {
                location_latitude: 48.861753,
                location_longitude: 2.338402,
                listingimgURL: "single-listing-detail-1.html",
                listingImg: "assets/img/listing/l-2.png",
                authorURL: "author-detail.html",
                authorImg: "assets/img/t-5.png",
                listingcategoryURL: "listing-search-v1.html",
				listingCategory:"زیبایی و آرایش",
				listingURL:"single-listing-detail-1.html",
				listingTitle:"Pretty Woman Smart Batra",
				listingLocation:"فیلادلفیا، ایالات متحده آمریکا",
				listingCall:"09390987658",
				listingTime:"5 days ago",
            },
            {
                location_latitude: 48.872111,
                location_longitude: 2.345151,
                listingimgURL: "single-listing-detail-1.html",
                listingImg: "assets/img/listing/l-2.png",
                authorURL: "author-detail.html",
                authorImg: "assets/img/t-6.png",
                listingcategoryURL: "listing-search-v1.html",
				listingCategory:"کلوپ شبانه",
				listingURL:"single-listing-detail-1.html",
				listingTitle:"کلوپ آنجلیکا استانبول",
				listingLocation:"اوماها، انگلستان",
				listingCall:"+91 985 740 6200",
				listingTime:"6 days ago",
            },
            {
                location_latitude: 48.865881,
                location_longitude: 2.341507,
                listingimgURL: "single-listing-detail-1.html",
                listingImg: "assets/img/listing/l-7.png",
                authorURL: "author-detail.html",
                authorImg: "assets/img/t-7.png",
                listingcategoryURL: "listing-search-v1.html",
				listingCategory:"CAFE & BAR",
				listingURL:"single-listing-detail-1.html",
				listingTitle:"Pizza Delight Cafe",
				listingLocation:"لیورپول، لندن",
				listingCall:"+91 856 542 4120",
				listingTime:"7 days ago",
            },
            {
                location_latitude: 48.867236,
                location_longitude: 2.34361,
                listingimgURL: "single-listing-detail-1.html",
                listingImg: "assets/img/listing/l-8.png",
                authorURL: "author-detail.html",
                authorImg: "assets/img/t-8.png",
                listingcategoryURL: "listing-search-v1.html",
				listingCategory:"SHOPPING MALL",
				listingURL:"single-listing-detail-1.html",
				listingTitle:"مرکز خرید ایران مال",
				listingLocation:"Old کالیفرنیا، ایالات متحده آمریکا",
				listingCall:"+91 548 658 7420",
				listingTime:"8 days ago",
            },
        ],
    },
    mapOptions = {
        zoom: 15,
        center: new google.maps.LatLng(48.867236, 2.34361),
        mapTypeId: google.maps.MapTypeId.satellite,
        mapTypeControl: !1,
        mapTypeControlOptions: { style: google.maps.MapTypeControlStyle.DROPDOWN_MENU, position: google.maps.ControlPosition.LEFT_CENTER },
        panControl: !1,
        panControlOptions: { position: google.maps.ControlPosition.TOP_RIGHT },
        zoomControl: !0,
        zoomControlOptions: { position: google.maps.ControlPosition.RIGHT_BOTTOM },
        scrollwheel: !1,
        scaleControl: !1,
        scaleControlOptions: { position: google.maps.ControlPosition.TOP_LEFT },
        streetViewControl: !0,
        streetViewControlOptions: { position: google.maps.ControlPosition.LEFT_TOP },
    };
for (var key in ((mapObject = new google.maps.Map(document.getElementById("map"), mapOptions)), markersData))
    markersData[key].forEach(function (o) {
        (marker = new google.maps.Marker({ position: new google.maps.LatLng(o.location_latitude, o.location_longitude), map: mapObject, icon: "assets/img/marker.png" })),
            void 0 === markers[key] && (markers[key] = []),
            markers[key].push(marker),
            google.maps.event.addListener(marker, "click", function () {
                closeInfoBox(), getInfoBox(o).open(mapObject, this), mapObject.setCenter(new google.maps.LatLng(o.location_latitude, o.location_longitude));
            });
    });
function hideAllMarkers() {
    for (var o in markers)
        markers[o].forEach(function (o) {
            o.setMap(null);
        });
}
function closeInfoBox() {
    $("div.infoBox").remove();
}
function getInfoBox(o) {
    return new InfoBox({
        content:
            '<div class="map-popup-wrap"><div class="map-popup"><div class="Goodup-grid-wrap"><div class="Goodup-grid-upper"><div class="Goodup-bookmark-btn"><button type="button"><i class="lni lni-heart-filled position-absolute"></i></button></div><div class="Goodup-grid-thumb"><a href="' +o.listingimgURL +'" class="d-block text-center m-auto"><img src="' +o.listingImg +'" class="img-fluid" alt=""></a></div></div><div class="Goodup-grid-fl-wrap"><div class="Goodup-caption px-3 py-2"><div class="Goodup-author"><a href="' +o.authorURL +'"><img src="' +o.authorImg +'" class="img-fluid circle" alt=""></a></div><div class="Goodup-cates"><a href="' +o.listingcategoryURL +'">' +o.listingCategory +'</a></div><h4 class="mb-0 ft-medium medium"><a href="' +o.listingURL +'" class="text-dark fs-md">' +o.listingTitle +'</a></h4><div class="Goodup-middle-caption mt-3"><div class="Goodup-location"><i class="fas fa-map-marker-alt"></i>' +o.listingLocation +'</div><div class="Goodup-call"><i class="fas fa-phone-alt"></i>' +o.listingCall +'</div></div></div><div class="Goodup-grid-footer py-3 px-3"><div class="Goodup-ft-last"><span class="small">' +o.listingTime +'</span></div></div></div></div></div></div>',
        disableAutoPan: !1,
        maxWidth: 0,
        pixelOffset: new google.maps.Size(10, 92),
        closeBoxMargin: "",
        closeBoxURL: "assets/img/close.png",
        isHidden: !1,
        alignBottom: !0,
        pane: "floatPane",
        enableEventPropagation: !0,
    });
}
function onHtmlClick(o, e) {
    google.maps.event.trigger(markers[o][e], "click");
}
new MarkerClusterer(mapObject, markers[key]);
