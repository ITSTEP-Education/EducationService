import React, { FC, useEffect, useState } from 'react';
import { ProductClientWrapper } from './ProductClient.styled';
import { TitleWrapper, BtnWrapper } from '../styles/ProductItem.styled';
import TabProductItemDto from '../ProductItemDto/TabProductItemDto';
import ProductItemRecord from '../ProductClientSections/ProductItemRecord';
import OptionsEducation from '../ProductClientSections/OptionsEducation';
import { Display } from '../styles/General.styled';
import { optionsForm } from '../ProductItem/ProductItemData';


interface ProductClientProps {}

type TClientProperty = {
   cltTimeProps: {
      educationForm: string,
      engineerType: string,
   },
   cltPayProps: {
      isInvitedPerson: boolean,
      payMethod: string,
      payPeriod: string,
   }
}

const ProductClient: FC<ProductClientProps> = (): React.FunctionComponentElement<ProductClientProps> => {

   const [isTableLoad, setIsTable1] = useState(false);
   const [nameProduct, setNameProduct] = useState<string | null>(null);
   const [educationForm, setEducationForm] = useState<string>('daily');

   const [clientProperty, setClientProperty] = useState<TClientProperty | null>({
      cltTimeProps:{
         educationForm: educationForm,
         engineerType: 'back-end',
      }, cltPayProps:{
         isInvitedPerson: false,
         payMethod: 'credit',
         payPeriod: 'monthly',
      }
   });

   const handleBtnLoad = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
      setIsTable1(true);
   }

   const handleNameProduct = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();
      setNameProduct(e.currentTarget.getElementsByTagName('td')[1].textContent);
   }

   const handleEducationForm = (e: React.FormEvent<HTMLElement>): void => {
      e.preventDefault();

      setEducationForm(e.currentTarget.title);
      setClientProperty({
         cltTimeProps:{
            educationForm: educationForm,
            engineerType: 'back-end',
         }, cltPayProps:{
            isInvitedPerson: false,
            payMethod: 'credit',
            payPeriod: 'monthly',
         }
      });

      console.log('clientProps after:', clientProperty);
   }

   return (
      <ProductClientWrapper>
         <div style={{width: '335px'}}>
            <Display _justify='none'>
               <TitleWrapper>EDUCATION SUBJECTS</TitleWrapper>
               <BtnWrapper onClick={handleBtnLoad}>LOAD</BtnWrapper>
            </Display>
            <TabProductItemDto isTableLoad={isTableLoad} _handleNameProduct={handleNameProduct}/>
         </div>

         <ProductItemRecord _nameProduct={nameProduct}/>

         <div style={{width: '500px', display: 'block', textAlign:'center'}}>
            <TitleWrapper style={{backgroundColor: '#6992b8'}}>EDUCATION OPTIONS</TitleWrapper>
            <OptionsEducation mainName='FORM' optionNames={optionsForm} _handleEducationForm={handleEducationForm}/>
         </div>
      </ProductClientWrapper>
     );
}

export default ProductClient;
