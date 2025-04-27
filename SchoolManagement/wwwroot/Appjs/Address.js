var HomeAddress = {
    GetCitiesByStateId: function (stateId) {
        $.ajax({
            type: "GET",
            url: '/Account/GetCitiesByStateId/' + stateId,
            cache: false,
            success: function (data) {
                var cityDropdown = $('select[name="HomeAddress.CityId"]');
                cityDropdown.empty(); // clear existing options

                cityDropdown.append($('<option>', {
                    value: '',
                    text: '-Select City-'
                }));

                $.each(data, function (i, city) {
                    cityDropdown.append($('<option>', {
                        value: city.uniqueId,
                        text: city.name
                    }));
                });
            }
        });
    }
};


var Address = {
    LoadAddressPartial: function (thisObj, addressId) {
        var isChecked = $(thisObj).is(':checked');
        console.log(isChecked);
        if (!isChecked) {
            $.ajax({
                url: '/Account/GetAddressPartial',
                type: 'GET',
                data: { addressId: addressId },
                success: function (result) {
                    $('#_addressPartial').html(result);
                },
                error: function (xhr, status, error) {
                    console.error('Error loading partial view:', error);
                }
            });
        }
        else { $('#_addressPartial').html(''); }
    }
}