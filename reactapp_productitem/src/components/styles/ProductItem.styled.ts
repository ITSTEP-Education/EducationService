import styled from "styled-components";

interface ITitleWrapper {
    fontSize?: number,
    fontColor?: string,
    bgColor?: string,
}

export const TitleWrapper = styled.p<ITitleWrapper>`
    font-size: ${props => props.fontSize? props.fontSize : 20}px;
    color: ${props => props.fontColor? props.fontColor : 'white'};
    background-color: ${props => props.bgColor? props.bgColor : 'grey'};
    font-weight: 600;
    text-shadow: 2px 2px 5px black;
    padding: 5px 10px;
`;

export const BtnWrapper = styled.button.attrs({
    type: "button",
    name: "load",
    autoFocus: true,
})`
    background-color: #335ac4;
    color: white;
    width: 90px;
    text-align: center;
    padding: 7px 0px;
    box-sizing: border-box;
    border: 1px solid #ddd;
    cursor: pointer;
`
