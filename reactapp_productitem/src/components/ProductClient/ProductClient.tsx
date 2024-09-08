import React, { FC, useEffect, useState } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../styles/ProductItem.styled';
import TabProductItemDbo from '../TabProductItemDbo/TabProductItemDbo';
import { Display } from '../styles/General.styled';
import axios from 'axios';

interface ProductClientProps {}

const ProductClient: FC<ProductClientProps> = () => {

   const handleBtnLoad = (): void => {

      const productsDbo = axios.create({
         baseURL: 'https://localhost:7296/api/ProductItem/',
         method: 'get',
         responseType: 'json',
      });
   
      console.log('reqeust btn load');
      
      productsDbo.get('check').
      then((responce) => {
         console.log('responce:', responce.data);
      }).
      catch((error) => {
         console.log('error:', error)
      });
   }


   useEffect(() => {handleBtnLoad}, []);

   return (
      <ProductClientWrapper>
        <div style={{width: '350px'}}>
           <Display _justify='none'>
              <TitleWrapper>Table 1. ProductItem (DTO)</TitleWrapper>
              <BtnWrapper onClick={handleBtnLoad}>LOAD</BtnWrapper>
           </Display>
           <TabProductItemDbo/>
        </div>
      </ProductClientWrapper>
     );
}

export default ProductClient;
