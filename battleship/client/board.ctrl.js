
(function(angular){

angular.findModule('app')
.controller('boardController',function($rootScope){
    
    function activate(){
       vm.mainBoard = Boards.find({_id:'9Yu7uX7kyd72FdAyT'});
       vm.subBoard = Boards.find({_id:'maAejW4cMKrYoFbhc'});
    }
    
    
    var vm = this;
    vm.mainBoard = {
       positions:[]
   };
   
   
    vm.subBoard = {
       positions:[]
   };

    activate();
    
    vm.insert=function(){
        Boards.insert(vm.subBoard);
        console.log('inserted');
    }
    
    vm.generate=function(boardName){
        $rootScope.$broadcast(boardName);
    }
       
})



}(window.angular));