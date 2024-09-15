import styled from 'styled-components';

interface Photo {
    _path?: string,  
}

export const PhotoImg = styled.img<Photo>`
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
`;

interface DisplayContent {
    _direction?: string;
    _justify?: string;
    _align?: string;
}

export const Display = styled.div<DisplayContent>`
    display: flex;
    flex-direction: ${props => props._direction || 'row'};
    justify-content: ${props => props._justify || 'space-between' };
    align-items: ${props => props._align || 'center'};
`;

type TBlockSpace = {
    space?: number | 3,
}

export const BlockSpace = styled.div<TBlockSpace>`
    clear: both;
    height: ${props => props.space? props.space : 3}px;
`;