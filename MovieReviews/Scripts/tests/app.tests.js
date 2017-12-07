describe('Review App Specs', function () {
    var module = angular.module('reviewApp');

    //Check if module exists
    it('Review App Should Load', function () {
        expect(module).not.toBeNull();
    });

    it('Module should have at least one dependency', function () {
        expect(module.requires.length).toBe(1);//Change value as per requirement        
    });

    it('Module should have Dependency on Route', function () {
        expect(module.requires).toContain('ngRoute');
    });

    


});