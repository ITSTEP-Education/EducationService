import { FC } from "react"
import { Display } from "../../ui/styled/General.styled";
import { TitleWrapper, BtnWrapper } from "../../ui/styled/ProductItem.styled";
import ProductItem from "../ProductItem/ProductItem";

interface IProductItemRecord{
    _width?: number,
    _isOptions: boolean,
    _nameProduct: string | null,
    _handleBtnSetUp: (e: React.FormEvent<HTMLElement>) => void,
}

const ProductItemRecord: FC<IProductItemRecord> = (props) => {

    if(props._nameProduct == 'none') return;

    return(
        <div style={{width: `${props._width || 500}px` }}>
            <Display _justify='none'>
                <TitleWrapper style={{width:'450px', textAlign: 'center'}}>SUBJECT DETAILS</TitleWrapper>
                <BtnWrapper onClick={props._handleBtnSetUp}>{!props._isOptions? 'SHOW' : 'HIDE'}</BtnWrapper>
            </Display>
            <ProductItem nameProduct={props._nameProduct}/>
        </div>
    );
}

export default ProductItemRecord;