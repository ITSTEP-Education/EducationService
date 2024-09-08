import React, { FC } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';

interface ProductClientProps {}

const ProductClient: FC<ProductClientProps> = () => (
 <ProductClientWrapper>
    ProductClient Component
 </ProductClientWrapper>
);

export default ProductClient;
