
(function (mp) {
    var AccountRegisterModelStep1 = function () {
        var self = this;

        self.FirstName = '';
        self.LastName = '';
        self.Address = '';
        self.City = '';
        self.State = '';
        self.ZipCode = '';

        self.Initialized = false;  // TO check wherether the step was initialized -- similar in other steps..To bypass situations when user directly goes to next without prev
    }
    mp.AccountRegisterModelStep1 = AccountRegisterModelStep1;

}(window.MyPlace));

(function (mp) {
    var AccountRegisterModelStep2 = function () {

        var self = this;

        self.LoginEmail = '';
        self.Password = '';
        self.PasswordConfirm = '';

        self.Initialized = false;
    }
    mp.AccountRegisterModelStep2 = AccountRegisterModelStep2;
}(window.MyPlace));

(function (mp) {
    var AccountRegisterModelStep3 = function () {

        var self = this;

        self.CreditCard = '';
        self.ExpDate = '';

        self.Initialized = false;
    }
    mp.AccountRegisterModelStep3 = AccountRegisterModelStep3;
}(window.MyPlace));