(function(angular){

angular.findModule('app')

.directive('board',function(){
   
   
   var _factory;
   var boardSize = 10;
   var _$scope;
   
        var hitsMade,
            hitsToWin;
            
            var ships;
   
   console.log('directive');
    return {
        restrict:'A',
        templateUrl :'client/board.html',
        link:link,
        controller:controller,
        scope:{
            board:"=",
            name:"@",
        }
    };
    controller.$inject=['$scope','factory'];
   function controller($scope,factory){
       _factory = factory;
       _$scope = $scope;
   }
    
    function link(scope){
               
               _$scope.$on(scope.name,function(){
                   distributeShips();
               })
               
      var  board = scope.board;
        scope.shot=shot;
        
        ships = [
            new _factory.Ship(2),
            new _factory.Ship(3),
            new _factory.Ship(3),
            new _factory.Ship(4),
            new _factory.Ship(5),
        ];
        
         //build board
         for (var y = 0; y < boardSize; y++) {
            board.positions[y] = [];
            for (var x = 0; x < boardSize; x++) {
                board.positions[y][x] = new _factory.Place(x,y);
            }
        }
        
        //set hits calc
        hitsMade = hitsToWin = 0;
         for (var i = 0, l = ships.length; i < l; i++) {
            hitsToWin += ships[i];
        }
        
        distributeShips();
    
    
    function distributeShips() {
        clearBoard()
        
        var pos, shipPlaced, vertical;
        for (var i = 0, l = ships.length; i < l; i++) {
            shipPlaced = false;
            vertical = randomBoolean();
            while (!shipPlaced) {
                pos = getRandomPosition();
                shipPlaced = placeShip(pos, ships[i], vertical);
            }
        }
    }
    
    function clearBoard(){
        for(var x =0 ; x < boardSize; x+=1)
            for(var y =0 ; y < boardSize; y+=1)
                board.positions[y][x].type = '';
    }
    function randomBoolean() {
        return (Math.round(Math.random()) == 1);
    }
    function getRandomPosition() {
        var x = Math.floor(Math.random() * 10),
            y = Math.floor(Math.random() * 10);

        return [x, y];
    }
    
    function placeShip(pos, ship, vertical) {
        // "pos" is ship origin
        var x = pos[0],
            y = pos[1],
            z = (vertical ? y : x),
            end = z + ship.cargo - 1;
            
            console.log("Ship placed at: {["+x+","+y+"],["+z+","+end+"]}");

        if (shipCanOccupyPosition( pos, ship, vertical)) {
            for (var i = z; i <= end; i++) {
                var place = vertical?board.positions[x][i]:board.positions[i][y];
                place.type = 'ship';
            }
            return true;
        }
        return false
    }
    
    function shipCanOccupyPosition(pos, ship, vertical) {
        // "pos" is ship origin
        var x = pos[0],
            y = pos[1],
            z = (vertical ? y : x),
            end = z + ship.cargo - 1;

        // board border is too close
        if (end > boardSize - 1) return false;

        // check if there's an obstacle
        for (var i = z; i <= end; i++) {
            var thisPos = (vertical ? board.positions[x][i].type : board.positions[i][y].type);
            if (thisPos === 'ship') return false;
        }

        return true;
    }
    
    function shot(id){
        console.log(id)
        
           var x = id[1],
            y = id[2];
            
            var place = board.positions[y][x];                

        if (place.type === 'ship' || place.type === 'hit') {
            place.type = 'hit';
            hitsMade++;
        } else place.type = 'miss';
    }
}
})


}(window.angular));