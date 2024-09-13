import React, { FC, useState } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../styles/ProductItem.styled';
import TabProductItemDto from '../ProductItemDto/TabProductItemDto';
import ProductItemRecord from '../ProductClientSections/ProductItemRecord';
import { Display } from '../styles/General.styled';


interface ProductClientProps {}

const ProductClient: FC<ProductClientProps> = (): React.FunctionComponentElement<ProductClientProps> => {

   const [isTableLoad, setIsTable1] = useState(false);
   const [nameProduct, setNameProduct] = useState<string | null>(null);

   const handleBtnLoad = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
      setIsTable1(true);
   }

   const handleNameProduct = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
      setNameProduct(e.currentTarget.getElementsByTagName('td')[1].textContent);
      // console.log(nameProduct);
   }

   return (
      <ProductClientWrapper>
         <div style={{width: '350px'}}>
            <Display _justify='none'>
               <TitleWrapper>Table 1. ProductItem (DTO)</TitleWrapper>
               <BtnWrapper onClick={handleBtnLoad}>LOAD</BtnWrapper>
            </Display>
            <TabProductItemDto isTableLoad={isTableLoad} _handleNameProduct={handleNameProduct}/>
         </div>

         <ProductItemRecord _nameProduct={nameProduct}/>

      </ProductClientWrapper>
     );
}

export default ProductClient;
