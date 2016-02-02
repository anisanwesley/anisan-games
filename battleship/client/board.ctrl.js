
(function(angular){

angular.findModule('app')
.controller('boardController',function($rootScope){
    
    function activate(){
    //   vm.mainBoard = Boards.findOne('9Yu7uX7kyd72FdAyT');
    //   vm.subBoard = Boards.findOne('maAejW4cMKrYoFbhc');
    }
    
    
    
    
    var vm = this;
    vm.subBoard={positions:[]};
    vm.mainBoard={positions:[]};
 
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