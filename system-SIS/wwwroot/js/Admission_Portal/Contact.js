function copyCurrentAddress() {
    const isChecked = document.getElementById('sameAsCurrentAddress').checked;

    if (isChecked) {
        document.getElementById('permanentHouseNo').value = document.getElementById('currentHouseNo').value;
        document.getElementById('permanentStreetName').value = document.getElementById('currentStreetName').value;
        document.getElementById('permanentVillage').value = document.getElementById('currentVillage').value;
        document.getElementById('permanentBarangay').value = document.getElementById('currentBarangay').value;
        document.getElementById('permanentCity').value = document.getElementById('currentCity').value;
        document.getElementById('permanentProvince').value = document.getElementById('currentProvince').value;
        document.getElementById('permanentZipCode').value = document.getElementById('currentZipCode').value;
    } else {
        document.getElementById('permanentHouseNo').value = '';
        document.getElementById('permanentStreetName').value = '';
        document.getElementById('permanentVillage').value = '';
        document.getElementById('permanentBarangay').value = '';
        document.getElementById('permanentCity').value = '';
        document.getElementById('permanentProvince').value = '';
        document.getElementById('permanentZipCode').value = '';
    }
}