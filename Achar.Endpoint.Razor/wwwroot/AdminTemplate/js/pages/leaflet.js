// Initialize simple leaflet map
var point = [29.728, 52.462];
var map = L.map("leaflet-map").setView(point, 14);
L.tileLayer("https://tile.openstreetmap.org/{z}/{x}/{y}.png").addTo(map);
marketLayer = L.marker(point).addTo(map)
.bindPopup("شیراز شهرک آرین، پارک علم و فناوری فارس...");



// Initialize multi map marker leaflet map
var locations = [
    ["نمایندگی یک", 29.728, 52.462],
    ["نمایندگی دو", 35.721, 51.334],
    ["نمایندگی سه", 31.897, 54.356]
];
  
var map = L.map("leaflet-map-markers").setView([31.897, 54.356], 5);
L.tileLayer(
    "http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {maxZoom: 14}
).addTo(map);
  
for (var i = 0; i < locations.length; i++) {
    marker = new L.marker([locations[i][1], locations[i][2]]).bindPopup(locations[i][0]).addTo(map);
}