
(function(angular){
  
  angular.findModule('app',[])
  
  .controller('shellController',function(){
    
    console.log('shellController');
    
    var vm = this;
        
    vm.log=function(id){
      console.log(id);
      window.makeShot(id[0],id[1])
    };    
  });
  
})(window.angular);

