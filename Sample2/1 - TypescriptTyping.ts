class Dog {
    say(): void {
        console.log("Gav");
    }
}

class Cat {
    say(): void {
        console.log("Meow");
    }
}


function say(cat: Cat) {
    cat.say();
}


var dog = new Dog();
say(dog);
