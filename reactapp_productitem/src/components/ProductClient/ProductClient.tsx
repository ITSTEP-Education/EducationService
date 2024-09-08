import React, { FC } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../styles/ProductItem.styled';
import TabProductItemDbo from '../TabProductItemDbo/TabProductItemDbo';
import { Display } from '../styles/General.styled';

interface ProductClientProps {}

const ProductClient: FC<ProductClientProps> = () => (
 <ProductClientWrapper>
   <div style={{width: '350px'}}>
      <Display _justify='none'>
         <TitleWrapper>Table 1. ProductItem (DTO)</TitleWrapper>
         <BtnWrapper>LOAD</BtnWrapper>
      </Display>
      <TabProductItemDbo/>
   </div>
 </ProductClientWrapper>
);

export default ProductClient;
