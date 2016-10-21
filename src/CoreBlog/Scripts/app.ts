declare var require: any

import Vue = require('vue')
var App = require('./components/app.vue').default

var vm = new Vue({
    el: '#hello',
    components: { App },
    render: (h:any) => h('app')
});
