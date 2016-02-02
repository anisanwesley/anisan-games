
(function(angular){


angular.findModule('app')
.controller('chatController',function($rootScope,$meteor){
    
    var vm = this;
   
   vm.boards = $meteor.collection(function(){
      return Boards.find({}) ;
   })
   
})



}(window.angular));