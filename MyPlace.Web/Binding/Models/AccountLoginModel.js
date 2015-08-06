(function (mp) {
    var AccountLoginModel = function () {
        var self = this;

        self.Login = '';
        self.Password = '';
        self.RememberMe = false;

    }
    mp.AccountLoginModel = AccountLoginModel;
}(window.MyPlace));