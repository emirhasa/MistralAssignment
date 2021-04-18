const formatDateFromIsoString = (date) => {
    return date.replace(/T.*/,'').split('-').reverse().join('.');
} 

export default formatDateFromIsoString;