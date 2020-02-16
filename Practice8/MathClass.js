class MathClass {

    @subtract(1)
    @multiply(2)
    addOne(number: number) {
        return number + 1;
    }
}

console.log(new MathClass().addOne(2)) //should print 5

function multiply(number: number) {
    return function (target: Object, key: string | symbol, descriptor: PropertyDescriptor) {
        const original = descriptor.value;
        descriptor.value = function (...args: any[]) {
            var result = original.apply(this, args);
            result = result * number;
            return result;
        };
        return descriptor;
    };
}

function subtract(number: number) {
    return function (target: Object, key: string | symbol, descriptor: PropertyDescriptor) {
        const original = descriptor.value;
        descriptor.value = function (...args: any[]) {
            var result = original.apply(this, args);
            result = result - number;
            result = result - number;
            return result;
        };
        return descriptor;
    };
}
