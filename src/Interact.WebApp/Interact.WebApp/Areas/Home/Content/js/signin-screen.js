(function () {
    var signinscreen = {
        userInfoGroup: $('.user-info-group'),
        userInfoTmpl: 'user-info-tmpl',
        signinCard: $('#signin-card'),
        timeOut: null,
        buildUserInfoBlock: function () {
            var _self = this;
            var html = template(_self.userInfoTmpl, { nickname: "lsh", sort: 21 });
            _self.userInfoGroup.append(html);

        },
        showSignCard: function () {
            var _self = this;
            _self.signinCard.show();
            _self.signinCard.find('.brilliancy').addClass('img-rotate');
            //定时开始
            _self.timeOut = setTimeout(function () {
                _self.signinCard.hide();
                _self.signinCard.find('.brilliancy').removeClass('img-rotate');
                //结束定时
                clearTimeout(_self.timeOut);
            }, 2000);
        },
        test: function () {
            var _self = this;
            setInterval(function () {
                _self.buildUserInfoBlock();
                _self.showSignCard();
            }, 3000);
        },
        init: function () {
            var _self = this;
            _self.test()
        }
    }
    signinscreen.init();
})()