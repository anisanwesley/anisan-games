(function(angular){
    
       var initialModules = [
  {name: 'app', deps: ['angular-meteor']}
];
    
    
angular.findModule=function(moduleName, deps) {
  deps = deps || [];
  try {
    return angular.module(moduleName);
  } catch (error) {
    return angular.module(moduleName, deps);
  }
}
    
 

initialModules.forEach(function(moduleDefinition) {
  angular.findModule(moduleDefinition.name, moduleDefinition.deps);
});

    
    
    
}(window.angular));