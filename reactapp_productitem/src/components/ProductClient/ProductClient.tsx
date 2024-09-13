import React, { FC, useState } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../styles/ProductItem.styled';
import TabProductItemDto from '../TabProductItemDto/TabProductItemDto';
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
      </ProductClientWrapper>
     );
}

export default ProductClient;
