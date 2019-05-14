(function () {
    var signinscreen = {
        userInfoGroup: $('.user-info-group'),
        userInfoTmpl: 'user-info-tmpl',
        signinCard: $('#signin-card'),
        userCardSort: $('.user-card-sort'),
        userCardNick: $('.user-card-nick'),
        userCardImg: $('.user-card-img'),
        signinCount: $('#signin-count'),
        _timeOut: null,
        _timeIntervel: null,
        getSigninCountBtn: $('#get-signin-count-btn'),
        buildUserInfoBlock: function (userinfo) {
            var _self = this;
            var html = template(_self.userInfoTmpl, userinfo);
            _self.userInfoGroup.append(html);
        },
        showSignCard: function (userInfo) {
            var _self = this;
            _self.signinCard.show();
            _self.userCardImg.attr('src', userInfo.headimage);
            _self.userCardNick.text(userInfo.nickname);
            _self.userCardSort.text(userInfo.sort);
            _self.signinCard.find('.brilliancy').addClass('img-rotate');
            //定时开始
            _self._timeOut = setTimeout(function () {
                _self.signinCard.hide();
                _self.signinCard.find('.brilliancy').removeClass('img-rotate');
                //结束定时
                clearTimeout(_self._timeOut);
            }, 2000);
        },
        //向签到屏追加签到数据
        appendSignInCard: function () {
            var _self = this;
            _self._timeIntervel = setInterval(function () {
                if (data.record.length <=0) {
                    clearInterval(_self.__timeIntervel);
                } else {
                    var userInfo = data.record.shift();
                    _self.buildUserInfoBlock({ headimage: userInfo.HeadImage, nickname: userInfo.NickName, sort: userInfo.Sort });
                }
            }, 2000);
        },
        initSignalr: function () {
            var _self = this;
            //1.获取连接
            var chat = $.connection.screenHub;
            //2.监听接口
            chat.client.sendSignInRecordToClient = function (record) {
                if (record == null || record.length <= 0)
                    return;
                record = $.parseJSON(record);
                var userInfo = { headimage: record.HeadImage, nickname: record.NickName, sort: 1 };
                var totalSignInRecord = _self.userInfoGroup.children('li');
                if (data.record.length <= 0) {
                   
                    userInfo.sort = totalSignInRecord.length+1;
                    _self.buildUserInfoBlock(userInfo);
                }
                else
                {
                    userInfo.sort = totalSignInRecord.length + 1;
                    if (_self.__timeIntervel ==null) {
                        _self.buildUserInfoBlock(userInfo);
                    } else {
                        data.record.push(record);
                    }
                }
                //卡片霸屏
                _self.showSignCard(userInfo);
            };
            chat.client.sendSignInCount = function (totalCount) {
              
                _self.signinCount.text(totalCount);
            };
            //3.开启监听
            $.connection.hub.start().done(function () {
               
                
            });
            setInterval(function () {
                chat.server.sendSignInCount(data.activityId);
            }, 5000);
        },

        test: function () {
            var _self = this;
            setInterval(function () {
                _self.buildUserInfoBlock();
                _self.showSignCard();
            }, 2000);
        },
        init: function () {
            var _self = this;
            _self.signinCount.text(data.record.length);
            // _self.test()
            _self.appendSignInCard();
            _self.initSignalr();
        }
    }
    signinscreen.init();
})()