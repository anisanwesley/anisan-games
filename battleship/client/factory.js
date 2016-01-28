(function(angular){
    
    angular.findModule('app')
    .factory('factory',function(){
        var fac = {
          Place : Place,
          Ship:Ship
        };
        
        function Place(x,y){
            var self = this;
            
            self.x=x;
            self.y=y;            
            
            self.id="P"+x+y;
            self.type = "";
            
        }
      
        function Ship(cargo){
            var self = this;
            
            self.cargo=cargo;
        }
       
        return fac;
    });
    
}(window.angular))