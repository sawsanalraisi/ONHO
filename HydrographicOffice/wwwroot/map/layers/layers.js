var wms_layers = [];


        var lyr_GoogleSatellite_0 = new ol.layer.Tile({
            'title': 'Google Satellite',
            'type': 'base',
            'opacity': 1.000000,
            
            
            source: new ol.source.XYZ({
    attributions: ' ',
                url: 'http://mt0.google.com/vt/lyrs=s&hl=en&x={x}&y={y}&z={z}'
            })
        });
var format_OmanENCPublishedChartsScheme_1 = new ol.format.GeoJSON();
var features_OmanENCPublishedChartsScheme_1 = format_OmanENCPublishedChartsScheme_1.readFeatures(json_OmanENCPublishedChartsScheme_1, 
            {dataProjection: 'EPSG:4326', featureProjection: 'EPSG:3857'});
var jsonSource_OmanENCPublishedChartsScheme_1 = new ol.source.Vector({
    attributions: ' ',
});
jsonSource_OmanENCPublishedChartsScheme_1.addFeatures(features_OmanENCPublishedChartsScheme_1);
var lyr_OmanENCPublishedChartsScheme_1 = new ol.layer.Vector({
                declutter: true,
                source:jsonSource_OmanENCPublishedChartsScheme_1, 
                style: style_OmanENCPublishedChartsScheme_1,
                interactive: true,
                title: '<img src="styles/legend/OmanENCPublishedChartsScheme_1.png" /> Oman ENC Published Charts Scheme'
            });
var format_OmanPaperChartsScheme_2 = new ol.format.GeoJSON();
var features_OmanPaperChartsScheme_2 = format_OmanPaperChartsScheme_2.readFeatures(json_OmanPaperChartsScheme_2, 
            {dataProjection: 'EPSG:4326', featureProjection: 'EPSG:3857'});
var jsonSource_OmanPaperChartsScheme_2 = new ol.source.Vector({
    attributions: ' ',
});
jsonSource_OmanPaperChartsScheme_2.addFeatures(features_OmanPaperChartsScheme_2);
var lyr_OmanPaperChartsScheme_2 = new ol.layer.Vector({
                declutter: true,
                source:jsonSource_OmanPaperChartsScheme_2, 
                style: style_OmanPaperChartsScheme_2,
                interactive: true,
                title: '<img src="styles/legend/OmanPaperChartsScheme_2.png" /> Oman Paper Charts Scheme'
            });

lyr_GoogleSatellite_0.setVisible(true);lyr_OmanENCPublishedChartsScheme_1.setVisible(true);lyr_OmanPaperChartsScheme_2.setVisible(true);
var layersList = [lyr_GoogleSatellite_0,lyr_OmanENCPublishedChartsScheme_1,lyr_OmanPaperChartsScheme_2];
lyr_OmanENCPublishedChartsScheme_1.set('fieldAliases', {'Chart_Name': 'Chart Name (Ar)', 'Chart_Nam1': 'Chart Name (Eng)', 'Chart_Numb': 'Chart Number', 'New_Editio': 'New Edition', 'Published': 'Published Date', 'ENC_Scale': 'ENC Scale', 'Band': 'ENC Band', 'Scale': 'Scale', });
lyr_OmanPaperChartsScheme_2.set('fieldAliases', {'Chart_Name': 'Chart Name (Arabic)', 'Chart_Nam1': 'Chart Name (English)', 'Scale': 'Scale', 'New_Editio': 'New Edition', 'Published': 'Published Date', 'Chart_Numb': 'Chart Number', });
lyr_OmanENCPublishedChartsScheme_1.set('fieldImages', {'Chart_Name': 'TextEdit', 'Chart_Nam1': 'TextEdit', 'Chart_Numb': 'TextEdit', 'New_Editio': 'TextEdit', 'Published': 'TextEdit', 'ENC_Scale': 'TextEdit', 'Band': 'Range', 'Scale': 'TextEdit', });
lyr_OmanPaperChartsScheme_2.set('fieldImages', {'Chart_Name': 'TextEdit', 'Chart_Nam1': 'TextEdit', 'Scale': 'TextEdit', 'New_Editio': 'TextEdit', 'Published': 'TextEdit', 'Chart_Numb': 'TextEdit', });
lyr_OmanENCPublishedChartsScheme_1.set('fieldLabels', {'Chart_Name': 'inline label', 'Chart_Nam1': 'inline label', 'Chart_Numb': 'inline label', 'New_Editio': 'inline label', 'Published': 'inline label', 'ENC_Scale': 'inline label', 'Band': 'inline label', 'Scale': 'inline label', });
lyr_OmanPaperChartsScheme_2.set('fieldLabels', {'Chart_Name': 'inline label', 'Chart_Nam1': 'inline label', 'Scale': 'inline label', 'New_Editio': 'inline label', 'Published': 'inline label', 'Chart_Numb': 'inline label', });
lyr_OmanPaperChartsScheme_2.on('precompose', function(evt) {
    evt.context.globalCompositeOperation = 'normal';
});