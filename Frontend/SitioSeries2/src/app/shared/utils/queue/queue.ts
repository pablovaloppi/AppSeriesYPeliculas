
export interface IQueue<T>{
    enqueue(item: T): void;
    dequeue(): T | undefined;
    size(): number;
}

export class Queue<T> implements IQueue<T>{
    private storage: T[] = [];
    
    constructor( list: T[]){
        list.forEach(element => {
            this.enqueue(element);
        });
    }
    enqueue(item: T): void {
        this.storage.push(item);
    }
    dequeue(): T | undefined {
        return this.storage.shift();
    }
    size(): number {
        return this.storage.length;
    }

}