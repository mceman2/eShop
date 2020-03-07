import { ProductRes } from './ProductRes.model';

export class ProductCartRes {
    public id: number;
    public cartId: number;
    public code: string;
    public quantity: number;
    public product: ProductRes;
    public shortDescription: string;
}