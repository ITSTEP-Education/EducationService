import styled from "styled-components";

type TNameOption = {
    isActive: boolean | false,
}

export const TypeOption = styled.p`
    font-size: 20px;
    color: white;
    background-color: #b09753;
    font-weight: 600;
    text-shadow: 2px 2px 5px black;
    padding: 5px 10px;
    width: 110px;
    text-align: center;
    float: left;
`;

export const NameOption = styled(TypeOption)<TNameOption>`
    background-color: ${props => props.isActive? '#49ed0e' : '#f5c020'};
    box-shadow: ${props => props.isActive? '-2px -2px 1px gray' : 'none'};
    width: 130px;
    cursor: pointer;

    &:hover {
        background-color: #c8ed0e;  
    }
`;
