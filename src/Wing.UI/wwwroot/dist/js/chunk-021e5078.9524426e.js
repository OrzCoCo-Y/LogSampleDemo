(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-021e5078"],{"11c5":function(e,t,a){"use strict";a.r(t);var r=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("d2-container",[a("template",{slot:"header"},[a("div",[a("el-input",{staticClass:"search",staticStyle:{width:"200px"},attrs:{clearable:"",placeholder:"请输入服务名称"},on:{change:e.search},model:{value:e.pageModel.data.serviceName,callback:function(t){e.$set(e.pageModel.data,"serviceName",t)},expression:"pageModel.data.serviceName"}}),a("el-input",{staticClass:"search",staticStyle:{width:"200px"},attrs:{clearable:"",placeholder:"请输入请求地址"},on:{change:e.search},model:{value:e.pageModel.data.requestUrl,callback:function(t){e.$set(e.pageModel.data,"requestUrl",t)},expression:"pageModel.data.requestUrl"}}),a("el-date-picker",{staticClass:"search",attrs:{type:"datetimerange","picker-options":e.pickerOptions,"range-separator":"至","start-placeholder":"请求时间","end-placeholder":"请求时间"},on:{change:e.search},model:{value:e.requestTime,callback:function(t){e.requestTime=t},expression:"requestTime"}}),a("el-button",{staticClass:"search",attrs:{type:"primary",icon:"el-icon-search"},on:{click:function(t){return t.preventDefault(),e.search(t)}}},[e._v("查询 ")])],1)]),a("div",{staticClass:"table-main"},[a("vxe-table",{ref:"tracerTable",staticClass:"mytable-scrollbar",attrs:{border:"",resizable:"",height:"100%",size:"medium",align:"center","highlight-hover-row":"","highlight-current-row":"","show-overflow":"","auto-resize":"","keep-source":"",stripe:"","edit-config":{trigger:"click",mode:"row",showStatus:!0},loading:e.loading,data:e.result.items,"mouse-config":{selected:!0},"tree-config":{transform:!0}},on:{"current-change":e.tracerRowSelected}},[a("vxe-column",{attrs:{field:"requestUrl",title:"请求地址",fixed:"left",align:"left",width:"400","tree-node":"",sortable:""}}),a("vxe-column",{attrs:{field:"serviceName",title:"服务名称",width:"200",sortable:""}}),a("vxe-column",{attrs:{field:"clientIp",title:"客户端请求IP",width:"150",sortable:""}}),a("vxe-column",{attrs:{field:"serviceUrl",title:"服务地址",width:"200",sortable:""}}),a("vxe-column",{attrs:{field:"requestType",title:"请求类型",width:"120",sortable:""}}),a("vxe-column",{attrs:{field:"requestTime",title:"请求时间",width:"200",formatter:["formatDate","yyyy-MM-dd HH:mm:ss"],sortable:""}}),a("vxe-column",{attrs:{field:"responseTime",title:"响应时间",width:"200",formatter:["formatDate","yyyy-MM-dd HH:mm:ss"],sortable:""}}),a("vxe-column",{attrs:{field:"usedMillSeconds",title:"请求耗时(毫秒)",width:"150",sortable:""}}),a("vxe-column",{attrs:{field:"requestMethod",title:"请求方式",width:"120",sortable:""}}),a("vxe-column",{attrs:{field:"requestValue",title:"请求内容",width:"300"}}),a("vxe-column",{attrs:{field:"responseValue",title:"响应内容",width:"300"}}),a("vxe-column",{attrs:{field:"statusCode",title:"状态码",width:"100",sortable:""}}),a("vxe-column",{attrs:{field:"exception",title:"异常说明",width:"300"}})],1),a("div",{staticStyle:{padding:"5px"}},[a("el-pagination",{attrs:{"current-page":e.pageModel.pageIndex,"page-size":e.pageModel.pageSize,"page-sizes":[15,25,35,45],layout:"total, sizes, prev, pager, next, jumper",total:e.result.totalCount},on:{"size-change":e.sizeChange,"current-change":e.currentChange}})],1)],1),a("div",{staticClass:"table-detail"},[a("el-tabs",{attrs:{type:"border-card"}},[a("el-tab-pane",{attrs:{label:"Http追踪明细"}},[a("vxe-table",{ref:"httpTracerTable",staticClass:"mytable-scrollbar",attrs:{border:"",resizable:"",size:"medium",align:"center","highlight-hover-row":"","highlight-current-row":"","show-overflow":"","auto-resize":"","keep-source":"",stripe:"","edit-config":{trigger:"click",mode:"row",showStatus:!0},loading:e.httpLoading,data:e.httpDetailData,"mouse-config":{selected:!0}}},[a("vxe-column",{attrs:{field:"requestUrl",title:"请求地址",fixed:"left",align:"left",width:"400",sortable:""}}),a("vxe-column",{attrs:{field:"requestType",title:"请求类型",width:"120",sortable:""}}),a("vxe-column",{attrs:{field:"requestTime",title:"请求时间",width:"200",formatter:["formatDate","yyyy-MM-dd HH:mm:ss"],sortable:""}}),a("vxe-column",{attrs:{field:"responseTime",title:"响应时间",width:"200",formatter:["formatDate","yyyy-MM-dd HH:mm:ss"],sortable:""}}),a("vxe-column",{attrs:{field:"usedMillSeconds",title:"请求耗时(毫秒)",width:"150",sortable:""}}),a("vxe-column",{attrs:{field:"requestMethod",title:"请求方式",width:"120",sortable:""}}),a("vxe-column",{attrs:{field:"requestValue",title:"请求内容",width:"300"}}),a("vxe-column",{attrs:{field:"responseValue",title:"响应内容",width:"300"}}),a("vxe-column",{attrs:{field:"statusCode",title:"状态码",width:"100",sortable:""}}),a("vxe-column",{attrs:{field:"exception",title:"异常说明",width:"300"}})],1)],1),a("el-tab-pane",{attrs:{label:"Sql追踪明细"}},[a("div",[a("vxe-table",{ref:"sqlTracerTable",staticClass:"mytable-scrollbar",attrs:{border:"",resizable:"",size:"medium",align:"center","highlight-hover-row":"","highlight-current-row":"","show-overflow":"","auto-resize":"","keep-source":"",stripe:"","edit-config":{trigger:"click",mode:"row",showStatus:!0},loading:e.sqlLoading,data:e.sqlDetailData,"mouse-config":{selected:!0}}},[a("vxe-column",{attrs:{field:"sql",title:"执行Sql",fixed:"left",align:"left",width:"300",sortable:""}}),a("vxe-column",{attrs:{field:"action",title:"操作类别",width:"150",sortable:""}}),a("vxe-column",{attrs:{field:"beginTime",title:"开始时间",width:"200",formatter:["formatDate","yyyy-MM-dd HH:mm:ss"],sortable:""}}),a("vxe-column",{attrs:{field:"endTime",title:"结束时间",width:"200",formatter:["formatDate","yyyy-MM-dd HH:mm:ss"],sortable:""}}),a("vxe-column",{attrs:{field:"usedMillSeconds",title:"耗时(毫秒)",width:"150",sortable:""}}),a("vxe-column",{attrs:{field:"exception",title:"异常说明",width:"300"}})],1)],1)])],1)],1)],2)},i=[],l=(a("d3b7"),a("ac1f"),a("3ca3"),a("841c"),a("ddb0"),a("96cf"),a("1da1")),s={name:"tracer",data:function(){return{loading:!1,httpLoading:!1,sqlLoading:!1,result:[],httpDetailData:[],sqlDetailData:[],requestTime:"",pageModel:{pageSize:15,pageIndex:1,data:{serviceName:"",downstreamUrl:"",requestUrl:"",requestTime:[]}},pickerOptions:{shortcuts:[{text:"最近一小时",onClick:function(e){var t=new Date,a=new Date;a.setTime(a.getTime()-36e5),e.$emit("pick",[a,t])}},{text:"最近一天",onClick:function(e){var t=new Date,a=new Date;a.setTime(a.getTime()-864e5),e.$emit("pick",[a,t])}},{text:"最近一周",onClick:function(e){var t=new Date,a=new Date;a.setTime(a.getTime()-6048e5),e.$emit("pick",[a,t])}}]}}},created:function(){this.search()},methods:{tracerRowSelected:function(e){var t=this;return Object(l["a"])(regeneratorRuntime.mark((function a(){var r;return regeneratorRuntime.wrap((function(a){while(1)switch(a.prev=a.next){case 0:return r=e.row.id,a.next=3,Promise.all([t.getHttpDetail(r),t.getSqlDetail(r)]);case 3:case"end":return a.stop()}}),a)})))()},search:function(){var e=this;return Object(l["a"])(regeneratorRuntime.mark((function t(){return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return e.loading=!0,e.requestTime?e.pageModel.data.requestTime=e.requestTime:e.pageModel.data.requestTime=[],t.next=4,e.$api.TRACER_LIST(e.pageModel);case 4:e.result=t.sent,e.loading=!1;case 6:case"end":return t.stop()}}),t)})))()},getHttpDetail:function(e){var t=this;return Object(l["a"])(regeneratorRuntime.mark((function a(){return regeneratorRuntime.wrap((function(a){while(1)switch(a.prev=a.next){case 0:return t.httpLoading=!0,a.next=3,t.$api.HTTP_TRACER_DETAIL(e);case 3:t.httpDetailData=a.sent,t.httpLoading=!1;case 5:case"end":return a.stop()}}),a)})))()},getSqlDetail:function(e){var t=this;return Object(l["a"])(regeneratorRuntime.mark((function a(){return regeneratorRuntime.wrap((function(a){while(1)switch(a.prev=a.next){case 0:return t.sqlLoading=!0,a.next=3,t.$api.SQL_TRACER_DETAIL(e);case 3:t.sqlDetailData=a.sent,t.sqlLoading=!1;case 5:case"end":return a.stop()}}),a)})))()},sizeChange:function(e){this.pageModel.pageSize=e,this.search()},currentChange:function(e){this.pageModel.pageIndex=e,this.search()}}},n=s,o=(a("f30c"),a("2877")),c=Object(o["a"])(n,r,i,!1,null,"fc87bffe",null);t["default"]=c.exports},1695:function(e,t,a){},f30c:function(e,t,a){"use strict";var r=a("1695"),i=a.n(r);i.a}}]);