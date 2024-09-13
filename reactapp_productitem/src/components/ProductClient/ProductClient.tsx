import React, { FC, useState } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../styles/ProductItem.styled';
import TabProductItemDto from '../ProductItemDto/TabProductItemDto';
import RecordProductItem from '../ProductItem/ProductItem';
import { Display } from '../styles/General.styled';


interface ProductClientProps {}

const ProductClient: FC<ProductClientProps> = (): React.FunctionComponentElement<ProductClientProps> => {

   const [isTableLoad, setIsTable1] = useState(false);

   const handleBtnLoad = (e: React.FormEvent<HTMLElement>): void => {

      e.preventDefault();
      setIsTable1(true);
   }

   return (
      <ProductClientWrapper>
         <div style={{width: '350px'}}>
            <Display _justify='none'>
               <TitleWrapper>Table 1. ProductItem (DTO)</TitleWrapper>
               <BtnWrapper onClick={handleBtnLoad}>LOAD</BtnWrapper>
            </Display>
            <TabProductItemDto isTableLoad={isTableLoad}/>
         </div>

         <div style={{width: '500px'}}>
            <Display _justify='none'>
               <TitleWrapper>Record. ProductItem</TitleWrapper>
               <BtnWrapper>SET ORDER</BtnWrapper>
            </Display>
            <RecordProductItem nameProduct={'js'}/>
         </div>
      </ProductClientWrapper>
     );
}

export default ProductClient;
